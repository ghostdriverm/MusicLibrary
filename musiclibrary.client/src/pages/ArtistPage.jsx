import React, { useEffect, useState } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import artistsService from '../services/artistsService';
import albumsService from '../services/albumsService';
import Artist from '../components/artist/Artist';

const ArtistPage = ({ albumOfTheDay, setAlbumOfTheDay }) => {
    const { artistId } = useParams();
    const navigate = useNavigate();
    const [artistInfo, setArtistInfo] = useState(null);
    const [albums, setAlbums] = useState([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);

    useEffect(() => {
        const fetchArtistInfo = async () => {
            try {
                const response = await artistsService.getArtistById(artistId);
                setArtistInfo(response);
                setLoading(false);
                setError(null);
            } catch (err) {
                setError(err.message);
                setLoading(false);
            }
        };

        const fetchAlbums = async () => {
            try {
                const albumsResponse = await albumsService.getAlbumsByArtistId(artistId);
                setAlbums(albumsResponse);
            } catch (err) {
                console.error('Error fetching albums:', err);
                // Handle error if needed
            }
        };

        fetchArtistInfo();
        fetchAlbums();
    }, [artistId]);

    const handleEditArtist = async (artistId, newName) => {
        try {
            await artistsService.updateArtist(artistId, { name: newName });

            // Update local state with the new artist name
            setArtistInfo(prevArtistInfo => ({
                ...prevArtistInfo,
                name: newName,
            }));

            // Update album of the day in state if it matches the edited artist
            if (albumOfTheDay && albumOfTheDay.artistId === artistId) {
                setAlbumOfTheDay(prevAlbum => ({
                    ...prevAlbum,
                    artistName: newName,
                }));
            }
        } catch (err) {
            console.error('Error updating artist name:', err);
            // Handle error if needed
        }
    };

    const handleDeleteArtist = async (artistId) => {
        try {
            const response = await artistsService.deleteArtist({ artistId });
            if (response.success) {
                // Handle deletion in local state
                setArtistInfo(null); // Clear artistInfo or handle removal as needed
                setAlbums([]); // Clear albums or handle removal as needed

                // Optionally navigate back to the main artists page or another appropriate action
                // history.push('/artists'); // Example if using react-router history
                navigate('/artists')
                // Show success message or handle UI update
            } else {
                console.error('Failed to delete artist:', response.message);
                // Handle failure or show error message
            }
        } catch (err) {
            console.error('Error deleting artist:', err);
            // Handle error if needed
        }
    };

    const handleAddAlbum = async (artistId, albumData) => {
        try {
            const response = await albumsService.createAlbum(artistId, albumData);
            console.log(response);
            if (response.success) {
                // Fetch updated albums list
                //const newAlbum = response.album;
                const updatedAlbums = await albumsService.getAlbumsByArtistId(artistId);
                setAlbums(updatedAlbums);
                console.log(albums);
                // Show success message or handle UI update
            } else {
                console.error('Failed to add album:', response.message);
                // Handle failure or show error message
            }
        } catch (err) {
            console.error('Error adding album:', err);
            // Handle error if needed
        }
    };

    const handleDeleteAllAlbums = async (artistId) => {
        try {
            await albumsService.deleteAllAlbums(artistId);
            setAlbums([]);
        } catch (err) {
            console.error('Error deleting all albums:', err);
            // Handle error if needed
        }
    };

    if (loading) return <div>Loading...</div>;
    if (error) return <div>Error: {error}</div>;

    return (
        <div className="page">
        <Artist
            artist={artistInfo}
            albums={albums}
            onEdit={handleEditArtist}
            onDelete={handleDeleteArtist}
            onAddAlbum={handleAddAlbum}
            onDeleteAllAlbums={handleDeleteAllAlbums}
            />
        </div>
    );
};

export default ArtistPage;
