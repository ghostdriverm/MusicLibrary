import React, { useState, useEffect } from 'react';
import AlbumOfTheDay from '../components/album/AlbumOfTheDay';
import albumsService from '../services/albumsService';
import AlbumGrid from '../components/album/AlbumGrid';

const HomePage = ({ albumOfDay, isLoading }) => {
    
    const [albums, setAlbums] = useState([]);
    const [visibleAlbums, setVisibleAlbums] = useState([]);
    const [page, setPage] = useState(1);
    const pageSize = 4;

    console.log(albumOfDay);

    useEffect(() => {
        const fetchAlbums = async () => {
            try {
                const fetchedAlbums = await albumsService.getAlbums(); // Fetch all albums
                setAlbums(fetchedAlbums);
                setVisibleAlbums(fetchedAlbums.slice(0, pageSize));
            } catch (error) {
                console.error('Error fetching albums:', error);
            }
        };
        fetchAlbums();
    }, []);

    const handleLoadMore = () => {
        const nextPage = page + 1;
        const newVisibleAlbums = albums.slice(0, nextPage * pageSize);
        setVisibleAlbums(newVisibleAlbums);
        setPage(nextPage);
    };

    const allAlbumsLoaded = visibleAlbums.length >= albums.length;

    return (
        <div className="page">
            {!isLoading ? (
                <> 
                    {albumOfDay && <AlbumOfTheDay album={albumOfDay} />}
                    <div className="featured-artists">
                    <h2>Featured Albums</h2>
                    <AlbumGrid albums={visibleAlbums} />
                    <button
                        onClick={handleLoadMore}
                        disabled={allAlbumsLoaded}
                        style={{
                            backgroundColor: allAlbumsLoaded ? 'grey' : 'initial',
                            cursor: allAlbumsLoaded ? 'default' : 'pointer',
                        }}
                    >
                        {allAlbumsLoaded ? 'No More Albums' : 'Load More'}
                        </button>
                    </div>
                </>
            ) : (
                <div>Loading...</div>
            )}
        </div>
    );
};

export default HomePage;
