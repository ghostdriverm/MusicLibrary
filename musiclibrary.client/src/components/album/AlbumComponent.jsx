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

    const handleAddSong = (e) => {
        e.preventDefault(); // Prevent default form submission

        const newSong = {
            title: newSongTitle,
            length: newSongLength,
        };
        addSong(newSong); // Pass the new song data to the addSong function

        // Reset form fields after adding the song
        setNewSongTitle('');
        setNewSongLength('');
    };

    const handleUpdateSong = (updatedSong) => {
        updateSong(updatedSong.songId, updatedSong);
    };

    const handleDeleteSong = (songId) => {
        deleteSong(songId);
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
        <div>
            <h1>{album.title}</h1>
            <h2>{album.artistName}</h2>
            <p>{album.description}</p>
            {error && <p style={{ color: 'red' }}>{error}</p>}
            {!loading && <Album3D frontCoverUrl={frontImage} backCoverUrl={backImage} />}
            <h3>Songs:</h3>
            <div>
                {album.songs && album.songs.map((song) => (
                    <div key={song.songId}>
                        <Song
                            song={song}
                            onEdit={handleUpdateSong}
                            onDelete={handleDeleteSong}
                        />
                    </div>
                ))}
            </div>
            <h4>Add New Song:</h4>
            <form onSubmit={handleAddSong}>
                <input
                    type="text"
                    value={newSongTitle}
                    onChange={(e) => setNewSongTitle(e.target.value)}
                    placeholder="New Song Title"
                />
                <input
                    type="text"
                    value={newSongLength}
                    onChange={(e) => setNewSongLength(e.target.value)}
                    placeholder="New Song Length"
                />
                <button type="submit">Add Song</button>
            </form>
            <button onClick={handleDeleteAllSongs}>Delete All Songs</button>
        </div>
    );
};

export default AlbumComponent;
