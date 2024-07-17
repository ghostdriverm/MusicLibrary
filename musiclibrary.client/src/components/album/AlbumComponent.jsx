import React, { useState, useEffect } from 'react';
import { searchAlbum, fetchCoverArt } from '../../services/imagesService';
import Album3D from './Album3D';
import Song from '../song/Song';

const AlbumComponent = ({ album, addSong, updateSong, deleteSong, deleteAllSongs }) => {
    const [frontImage, setFrontImage] = useState(null);
    const [backImage, setBackImage] = useState(null);
    const [error, setError] = useState(null);
    const [loading, setLoading] = useState(true);
    const [songs, setSongs] = useState(album.songs || []);
    const [newSongTitle, setNewSongTitle] = useState('');
    const [newSongLength, setNewSongLength] = useState('');
    const [formErrors, setFormErrors] = useState({});

    useEffect(() => {
        let isMounted = true;

        const getAlbumCoverArt = async () => {
            try {
                const mbids = await searchAlbum(album.artistName, album.title);
                if (mbids.length === 0) {
                    throw new Error('Album not found');
                }

                const images = await fetchCoverArt(mbids);
                if (!images || images.length === 0) {
                    throw new Error('Cover art not found');
                }

                if (isMounted) {
                    const front = images.find(img => img.type === 'Front');
                    const back = images.find(img => img.type === 'Back');
                    if (front) setFrontImage(front.image);
                    if (back) setBackImage(back.image);
                    setLoading(false);
                    setError(null);
                }
            } catch (err) {
                if (isMounted) {
                    setError(err.message);
                    setLoading(false);
                }
            }
        };

        if (album.artistName && album.title) {
            getAlbumCoverArt();
        }

        return () => {
            isMounted = false; // Clean up to avoid setting state on unmounted component
        };
    }, [album.artistName, album.title]);

    useEffect(() => {

        setSongs(album.songs);

    }, [album.songs]);

    // Validation for the songs 
    const validateSong = (title, length) => {
        const errors = {};
        if (!title.trim()) {
            errors.title = 'Song title cannot be empty';
        }
        const lengthRegex = /^([1-9]?\d|[1-9]\d):\d{2}$/;
        if (!lengthRegex.test(length)) {
            errors.length = 'Length must be in format mm:ss or m:ss';
        } else {
            const [minutes, seconds] = length.split(':').map(Number);
            if (seconds >= 60) {
                errors.length = 'Seconds must be less than 60';
            }
        }
        return errors;
    };

    const handleAddSong = async (e) => {
        e.preventDefault(); // Prevent default form submission

        const errors = validateSong(newSongTitle, newSongLength);
        if (Object.keys(errors).length > 0) {
            setFormErrors(errors);
            return;
        }

        const newSong = {
            title: newSongTitle,
            length: newSongLength,
        };
        const updatedAlbum = await addSong(newSong); // Add the new song and get the updated album // Pass the new song data to the addSong function

        // Update the local state with the new list of songs
        setSongs(updatedAlbum.songs);

        // Reset form fields after adding the song
        setNewSongTitle('');
        setNewSongLength('');
        setFormErrors({});
    };

    const handleUpdateSong = (updatedSong) => {
        const errors = validateSong(updatedSong.title, updatedSong.length);
        if (Object.keys(errors).length > 0) {
            const errorMessages = Object.values(errors).join("\n");
            alert("Validation errors: " + errorMessages);
            return;
        }
        updateSong(updatedSong.songId, updatedSong);
    };

    const handleDeleteSong = (songId) => {
        if (window.confirm(`Are you sure you want to delete this song?`)) {
            deleteSong(songId);
        }
    };

    const handleDeleteAllSongs = async () => {
        if (window.confirm("Are you sure you want to delete all songs?")) {
            try {
                await deleteAllSongs(); // Call the deleteAllSongs function passed from AlbumPage
            } catch (err) {
                console.error('Error deleting all songs:', err);
            }
        }
    };

    return (
        <div className="album-component">
            <div className="album-component-title">
                <h1>{album.title}</h1>
                <h2>{album.artistName}</h2>
            </div>
            {error && <p style={{ color: 'red' }}>{error}</p>}
            {!loading && <Album3D frontCoverUrl={frontImage} backCoverUrl={backImage} />}
            <div className="album-description">
                <p>{album.description}</p>
            </div>

            <h3>Songs:</h3>
            <div className="song-grid">
                {songs.map((song) => (
                    <Song
                        key={song.songId}
                        song={song}
                        onEdit={handleUpdateSong}
                        onDelete={handleDeleteSong}
                    />
                ))}
            </div>
            <div className="song-grid">
                <div className="song-grid-component">
                    <h4>Add New Song:</h4>
                    <form onSubmit={handleAddSong} className="add-song-form">
                    <div className="form-input-element">
                        <input
                            type="text"
                            value={newSongTitle}
                            onChange={(e) => setNewSongTitle(e.target.value)}
                            placeholder="New Song Title"
                            requried
                        />
                            {formErrors.title && <p style={{ color: 'red' }}>{formErrors.title}</p>}
                        </div>
                        <div className="form-input-element">
                        <input
                            type="text"
                            value={newSongLength}
                            onChange={(e) => setNewSongLength(e.target.value)}
                            placeholder="New Song Length"
                            required
                        />
                            {formErrors.length && <p style={{ color: 'red' }}>{formErrors.length}</p>}
                        </div>
                        <button type="submit" className="song-submit">Add Song</button>
                    </form>
                </div>
            </div>
            <button onClick={handleDeleteAllSongs}>Delete All Songs</button>
        </div>
    );
};

export default AlbumComponent;
