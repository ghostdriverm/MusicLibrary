import React, { useEffect, useState } from 'react';
import artistsService from '../services/artistsService';
import albumsService from '../services/albumsService';
import ArtistGrid from '../components/artist/ArtistGrid';

const ArtistsPage = ({ albumOfTheDay, setAlbumOfTheDay }) => {
    const [artists, setArtists] = useState([]);
    const [visibleArtists, setVisibleArtists] = useState([]);
    const [page, setPage] = useState(1);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);
    const pageSize = 8;

    useEffect(() => {
        const fetchArtists = async () => {
            try {
                const artistsResponse = await artistsService.getAllArtists();
                const artistsWithAlbums = await Promise.all(
                    artistsResponse.map(async artist => {
                        const albums = await albumsService.getAlbumsByArtistId(artist.artistId);
                        return { ...artist, albums };
                    })
                );
                setArtists(artistsWithAlbums);
                setVisibleArtists(artistsWithAlbums.slice(0, pageSize));
                setLoading(false);
                setError(null);
            } catch (err) {
                setError(err.message);
                setLoading(false);
            }
        };

        fetchArtists();
    }, []);

    const handleLoadMore = () => {
        const nextPage = page + 1;
        const newVisibleArtists = artists.slice(0, nextPage * pageSize);
        setVisibleArtists(newVisibleArtists);
        setPage(nextPage);
    };

    const allArtistsLoaded = visibleArtists.length >= artists.length;

    const handleEditArtist = async (artistId, newName) => {
        try {
            await artistsService.updateArtist(artistId, { name: newName });

            // Update local state with the new artist name
            setArtists(prevArtists => prevArtists.map(artist =>
                artist.artistId === artistId ? { ...artist, name: newName } : artist
            ));

            setVisibleArtists(prevVisibleArtists => prevVisibleArtists.map(artist =>
                artist.artistId === artistId ? { ...artist, name: newName } : artist
            ));

            // Update album of the day in state if it matches the edited artist
            if (albumOfTheDay && albumOfTheDay.artistId === artistId) {
                setAlbumOfTheDay(prevAlbum => ({
                    ...prevAlbum,
                    artistName: newName,
                }));
            }
        } catch (err) {
            console.error('Error updating artist name:', err);
        }
    };

    const handleDeleteArtist = async (artistId) => {
        if (!window.confirm('Are you sure you want to delete this artist?')) {
            return;
        }
        try {
            const response = await artistsService.deleteArtist({ artistId });
            if (response.success) {
                setArtists((prevArtists) =>
                    prevArtists.filter((artist) => artist.artistId !== artistId)
                );
                setVisibleArtists((prevVisibleArtists) =>
                    prevVisibleArtists.filter((artist) => artist.artistId !== artistId)
                );
            } else {
                console.error('Failed to delete artist:', response.message);
            }
        } catch (err) {
            console.error('Error deleting artist:', err);
        }
    };

    const handleAddArtist = async (artistName) => {
        if (artistName.trim() === '') {
            alert('Artist name cannot be empty.');
            return;
        }

        try {
            const response = await artistsService.createArtist({ name: artistName });
            if (response.success) {
                const newArtist = response.artist;
                setArtists((prevArtists) => [...prevArtists, newArtist]);
                setVisibleArtists((prevVisibleArtists) => [...prevVisibleArtists, newArtist]);
            } else {
                console.error('Failed to create artist:', response.message);
            }
        } catch (error) {
            console.error('Error creating artist:', error);
        }
    };

    if (loading) return <div>Loading...</div>;
    if (error) return <div>Error: {error}</div>;

    return (
        <div className="page">
            <ArtistGrid
                artists={visibleArtists}
                onEdit={handleEditArtist}
                onDelete={handleDeleteArtist}
                onAdd={handleAddArtist}
            />
            <div className="button-grid">
            <button
                onClick={handleLoadMore}
                disabled={allArtistsLoaded}
                style={{
                    backgroundColor: allArtistsLoaded ? 'grey' : 'initial',
                    cursor: allArtistsLoaded ? 'default' : 'pointer',
                }}
            >
                {allArtistsLoaded ? 'No More Artists' : 'Load More'}
                </button>
            </div>
        </div>
    );
};

export default ArtistsPage;
