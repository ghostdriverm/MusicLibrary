import React, { useState, useEffect } from 'react';
import { searchAlbum, fetchCoverArt } from '../../services/imagesService';
import { Link } from 'react-router-dom';

const AlbumGridComponent = ({ album }) => {
    const [frontImage, setFrontImage] = useState(null);
    const [error, setError] = useState(null);
    const [loading, setLoading] = useState(true);

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
                    if (front) setFrontImage(front.image);
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


    return (
        <div className="grid-component">
            <div className="grid-component-info">
                
                <p className="album-title"><Link to={`/artists/${encodeURIComponent(album.artistId)}/albums/${encodeURIComponent(album.albumId)}`}>{album.title}</Link></p>
                <p className="artist-name"><Link to={`/artists/${encodeURIComponent(album.artistId)}`}>{album.artistName}</Link></p>
            </div>
            {error && <p style={{ color: 'red' }}>{error}</p>}
            {!loading ?
                (
                    <div>
                        <img src={frontImage} alt="Front cover" style={{ width: '100px' }} />
                    </div>
                ) : <div>Loading...</div>}
            </div>
    );
};

export default AlbumGridComponent;
