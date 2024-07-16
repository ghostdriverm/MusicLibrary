import React from 'react';
import ArtistGridComponent from './ArtistGridComponent';

const ArtistGrid = ({ artists, onEdit, onDelete, onAdd }) => (
    <div className="artist-grid">
        <button onClick={() => onAdd(prompt('Enter artist name:'))}>Add Artist</button>
        {artists.map((artist) => (
            <ArtistGridComponent
                key={artist.artistId}
                artist={artist}
                onEdit={onEdit}
                onDelete={onDelete}
            />
        ))}
    </div>
);

export default ArtistGrid;
