import React, { useState, useEffect } from 'react';
import Album3D from './Album3D';
import { searchAlbum, fetchCoverArt } from '../../services/imagesService';
import { Link } from 'react-router-dom';

const AlbumOfTheDay = ({ album }) => {
    const [frontImage, setFrontImage] = useState(null);
    const [backImage, setBackImage] = useState(null);
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

    return (
        <div className="album-of-the-day">
            <h1>Today's album is: 
                <Link to={`/artists/${encodeURIComponent(album.artistId)}/albums/${encodeURIComponent(album.albumId)}`}> {album.title}</Link>
            </h1>
            <h1>by <Link to={`/artists/${encodeURIComponent(album.artistId)}`}> {album.artistName}</Link></h1>
            {loading ? <div>Loading</div> : <Album3D frontCoverUrl={frontImage ? frontImage : null } backCoverUrl={backImage ? backImage : null} />}
            {console.log("URLS in AOTD: ", frontImage, backImage)}
            <div className="album-description">
                <p>{album.description}</p>
            </div>
            {error && <div>{error}</div> }
        </div>
    )
}

export default AlbumOfTheDay;