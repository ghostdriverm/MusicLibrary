import React, { useState } from 'react';
import { Link } from 'react-router-dom';

const ArtistGridComponent = ({ artist, onEdit, onDelete }) => {
    const [editMode, setEditMode] = useState(false);
    const [newArtistName, setNewArtistName] = useState('');

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

    return (
        <div className="artist-grid-component">
            <h2><Link to={`/artists/${artist.artistId}`}>{artist.name}</Link></h2>
            <div className="buttons">
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
                <button onClick={handleEditClick}>Edit Artist Name</button>
            )}
            <button onClick={() => onDelete(artist.artistId)}>Delete Artist</button>
            </div>
        </div>
    );
};

export default ArtistGridComponent;
