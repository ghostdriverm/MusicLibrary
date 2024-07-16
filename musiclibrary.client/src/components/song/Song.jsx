import React, { useState } from 'react';

const Song = ({ song, onEdit, onDelete }) => {
    const [newTitle, setNewTitle] = useState(song.title);
    const [newLength, setNewLength] = useState(song.length);
    const [editMode, setEditMode] = useState(false);

    const handleSave = () => {
        onEdit({ ...song, title: newTitle, length: newLength });
        setEditMode(false);
    };

    const handleCancel = () => {
        setNewTitle(song.title);
        setNewLength(song.length);
        setEditMode(false);
    };

    const handleDelete = () => {
        onDelete(song.songId);
    };

    return (
        <div>
            {editMode ? (
                <div>
                    <input
                        type="text"
                        value={newTitle}
                        onChange={(e) => setNewTitle(e.target.value)}
                    />
                    <input
                        type="text"
                        value={newLength}
                        onChange={(e) => setNewLength(e.target.value)}
                    />
                    <button onClick={handleSave}>Save</button>
                    <button onClick={handleCancel}>Cancel</button>
                </div>
            ) : (
                <div>
                    <p>Title: {song.title}</p>
                    <p>Length: {song.length}</p>
                    <button onClick={() => setEditMode(true)}>Edit</button>
                    <button onClick={handleDelete}>Delete</button>
                </div>
            )}
        </div>
    );
};

export default Song;
