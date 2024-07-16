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
        onEdit(artist.artistId, newArtistName);
        setEditMode(false);
    };

    const handleDelete = () => {
        if (window.confirm(`Are you sure you want to delete ${artist.name}?`)) {
            onDelete(artist.artistId);
        }
    };

    const handleAddAlbum = (e) => {
        e.preventDefault();
        onAddAlbum(artist.artistId, { title: newAlbumTitle, description: newAlbumDescription });
        setNewAlbumTitle('');
        setNewAlbumDescription('');
    };

    const handleDeleteAllAlbums = () => {
        if (window.confirm(`Are you sure you want to delete all albums for ${artist.name}?`)) {
            onDeleteAllAlbums(artist.artistId);
        }
    };

    return (
        <div>
            <h1>Artist: {artist.name}</h1>
            {editMode ? (
                <div>
                    <input
                        type="text"
                        value={newArtistName}
                        onChange={(e) => setNewArtistName(e.target.value)}
                    />
                    <button onClick={handleSaveEdit}>Save</button>
                    <button onClick={handleCancelEdit}>Cancel</button>
                </div>
            ) : (
                <div>
                    <button onClick={handleEditClick}>Edit Artist Name</button>
                    <button onClick={handleDelete}>Delete Artist</button>
                </div>
            )}
            
            <button onClick={handleDeleteAllAlbums}>Delete All Albums</button>
            <h3>Albums:</h3>
            <ul>
                {albums.map(album => (
                    <li key={album.albumId}>
                        <Link to={`/artists/${artist.artistId}/albums/${album.albumId}`}>{album.title}</Link>
                    </li>
                ))}
            </ul>

            <h3>Add Album:</h3>
            <form onSubmit={handleAddAlbum}>
                <input
                    type="text"
                    placeholder="Enter album title"
                    value={newAlbumTitle}
                    onChange={(e) => setNewAlbumTitle(e.target.value)}
                />
                <input
                    type="text"
                    placeholder="Enter album description"
                    value={newAlbumDescription}
                    onChange={(e) => setNewAlbumDescription(e.target.value)}
                />
                <button type="submit">Add Album</button>
            </form>
        </div>
    );
};

export default Artist;
