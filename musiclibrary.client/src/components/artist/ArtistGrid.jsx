import React from 'react';
import ArtistGridComponent from './ArtistGridComponent';

const ArtistGrid = ({ artists, onEdit, onDelete, onAdd }) => (
    <div className="artist-grid">
        <div className="button-grid">
            <button onClick={() => onAdd(prompt('Enter artist name:'))}>Add Artist</button>
        </div>
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
