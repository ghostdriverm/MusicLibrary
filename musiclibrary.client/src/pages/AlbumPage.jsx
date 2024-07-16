import React, { useState, useEffect } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import albumsService from '../services/albumsService';
import AlbumComponent from '../components/album/AlbumComponent';
import songsService from '../services/songsService';

const AlbumPage = ({ albumOfTheDay, setAlbumOfTheDay }) => {
    const { artistId, albumId } = useParams();
    const [albumInfo, setAlbumInfo] = useState(null);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);
    const navigate = useNavigate();

    useEffect(() => {
        const fetchAlbum = async () => {
            try {
                const albumData = await albumsService.getAlbumById(artistId, albumId);
                setAlbumInfo(albumData);
                setLoading(false);
            } catch (err) {
                setError(err.message);
                setLoading(false);
            }
        };

        fetchAlbum();
    }, [artistId, albumId]);

    const handleAddSong = async (newSong) => {
        try {
            const updatedAlbum = await songsService.createSong(artistId, albumId, newSong);
            if (updatedAlbum.success) {
                const updatedAlbumInfo = await albumsService.getAlbumById(artistId, albumId);
                setAlbumInfo(updatedAlbumInfo);
            } else {
                console.error('Failed to add song:', updatedAlbum.message);
            }
        } catch (err) {
            setError(err.message);
        }
    };

    const handleUpdateSong = async (songId, updatedSong) => {
        try {
            await songsService.updateSong(artistId, albumId, songId, updatedSong);
            setAlbumInfo((prevAlbumInfo) => ({
                ...prevAlbumInfo,
                songs: prevAlbumInfo.songs.map((song) =>
                    song.songId === songId ? { ...song, ...updatedSong } : song
                ),
            }));
        } catch (err) {
            console.error(`Error updating song with ID ${songId}:`, err);
        }
    };

    const handleDeleteSong = async (songId) => {
        try {
            const updatedAlbum = await songsService.deleteSong(artistId, albumId, songId);
            console.
            setAlbumInfo(updatedAlbum);
        } catch (err) {
            setError(err.message);
        }
    };

    const handleDeleteAllSongs = async () => {
        try {
            const updatedAlbum = await songsService.deleteAllSongs(artistId, albumId);
            console.log(updatedAlbum);
            setAlbumInfo(updatedAlbum);
        } catch (err) {
            setError(err.message);
        }
    };

    if (error) return <div>Error: {error}</div>;

    return (
        <div className="page">
            {albumInfo && (
                <AlbumComponent
                    album={albumInfo}
                    addSong={handleAddSong}
                    updateSong={handleUpdateSong}
                    deleteSong={handleDeleteSong}
                    deleteAllSongs={handleDeleteAllSongs}
                />
            )}
        </div>
    );
};

export default AlbumPage;
