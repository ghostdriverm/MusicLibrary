import React, { useState } from 'react';
import { Link } from 'react-router-dom';

const Artist = ({ artist, albums, onEdit, onDelete, onAddAlbum, onDeleteAllAlbums }) => {
    const [editMode, setEditMode] = useState(false);
    const [newArtistName, setNewArtistName] = useState('');
    const [newAlbumTitle, setNewAlbumTitle] = useState('');
    const [newAlbumDescription, setNewAlbumDescription] = useState('');

    const handleEditClick = () => {
        setEditMode(true);
        setNewArtistName(artist.name);
    };

    const handleCancelEdit = () => {
        setEditMode(false);
        setNewArtistName('');
    };

    const handleSaveEdit = () => {
        if (newArtistName.trim() === '') {
            setErrors({ artistName: 'Artist name cannot be empty' });
            return;
        }
        onEdit(artist.artistId, newArtistName);
        setEditMode(false);
        setErrors({});
    };

    const handleDelete = () => {
        if (window.confirm(`Are you sure you want to delete ${artist.name}?`)) {
            onDelete(artist.artistId);
        }
    };

    const handleAddAlbum = (e) => {
        e.preventDefault();
        const newErrors = {};
        if (newAlbumTitle.trim() === '') {
            newErrors.albumTitle = 'Album title cannot be empty';
        }
        if (newAlbumDescription.trim() === '') {
            newErrors.albumDescription = 'Album description cannot be empty';
        }
        if (Object.keys(newErrors).length > 0) {
            setErrors(newErrors);
            return;
        }
        onAddAlbum(artist.artistId, { title: newAlbumTitle, description: newAlbumDescription });
        setNewAlbumTitle('');
        setNewAlbumDescription('');
        setErrors({});
    };

    const handleDeleteAllAlbums = () => {
        if (window.confirm(`Are you sure you want to delete all albums for ${artist.name}?`)) {
            onDeleteAllAlbums(artist.artistId);
        }
    };

    const handleSubmit = () => {
        document.getElementById('add-album-form').submit();
    };

    return (
        <div className="artist">
            <div className="artist-grid-component">
                <h1>{artist.name}</h1>

                {editMode ? (
                    <>
                        <div className="edit">
                            <input
                                type="text"
                                value={newArtistName}
                                onChange={(e) => setNewArtistName(e.target.value)}
                                required
                            />
                        </div>
                        <div className="buttons">
                            <div className="button">
                                <button onClick={handleSaveEdit}>Save</button>
                            </div>
                            <div className="button">
                                <button onClick={handleCancelEdit}>Cancel</button>
                            </div>
                        </div>
                    </>
                ) : (
                    <>
                        <div className="edit"></div>
                        <div className="buttons">
                            <div className="button">
                                <button onClick={handleEditClick}>Edit Artist Name</button>
                            </div>
                            <div className="button">
                                <button onClick={handleDelete}>Delete Artist</button>
                            </div>
                        </div>
                    </>
                )}
            </div>
            <div className="button-grid">
                <button onClick={handleDeleteAllAlbums}>Delete All Albums</button>
            </div>
            <div className="artist-grid-component-centered">
                <h3>Albums</h3>
            </div>
            <div className="artist-grid-component-centered">
                <ul>
                    {albums.map(album => (
                        <>
                            <div className="artist-grid-component-item">
                                <li key={album.albumId} className="album-title">
                                    <Link to={`/artists/${artist.artistId}/albums/${album.albumId}`}>{album.title}</Link>
                                </li>
                            </div>
                            <div className="divider"></div>
                        </>
                    ))}
                </ul>
            </div>
            <div className="artist-grid-component">
                <h3>Add Another Album</h3>
            <div>
            <form id="add-album-form" onSubmit={handleAddAlbum}>
                <input
                    type="text"
                    placeholder="Enter album title"
                    value={newAlbumTitle}
                    onChange={(e) => setNewAlbumTitle(e.target.value)}
                    required
                />
                <input
                    type="text"
                    placeholder="Enter album description"
                    value={newAlbumDescription}
                    onChange={(e) => setNewAlbumDescription(e.target.value)}
                    required
                />
                    </form>
                </div>
                <div className="buttons">
                <div className="button">
                    <button type="button" onClick={handleSubmit}>Add Album</button>
                    </div>
                </div>
            </div>
        </div>
    );
};

export default Artist;
