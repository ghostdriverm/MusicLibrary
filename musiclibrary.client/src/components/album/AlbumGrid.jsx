import React from 'react';
import AlbumGridComponent from './AlbumGridComponent';

const AlbumGrid = ({ albums }) => (
    <div className="album-grid">
        {albums.map((album) => (
            <AlbumGridComponent key={album.albumId} album={album} />
        ))}
    </div>
);

export default AlbumGrid;
