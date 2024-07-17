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
            <div className="artist-link">
                <h2><Link to={`/artists/${artist.artistId}`}>{artist.name}</Link></h2>
            </div>

            {editMode ? (
                <>
                    <div className="edit">
                        <div>
                            <input
                                className="input-field"
                                type="text"
                                value={newArtistName}
                                onChange={(e) => setNewArtistName(e.target.value)}
                                required
                            />
                        </div>
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
                        <div className="edit">
                        </div>
                        <div className="buttons">
                    <div className="button">
                                <button onClick={handleEditClick}>Edit Artist Name</button>
                            </div>
                            <div className="button">
                                <button onClick={() => onDelete(artist.artistId)}>Delete Artist</button>
                            </div>
                    </div>
                </>
            )}
        </div>
    );
};

export default ArtistGridComponent;
