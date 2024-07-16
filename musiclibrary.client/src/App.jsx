import React, { useState, useEffect } from 'react';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import './App.css';
import Navbar from './components/common/Navbar';
import HomePage from './pages/HomePage';
import ArtistPage from './pages/ArtistPage';
import ArtistsPage from './pages/ArtistsPage';
import AlbumPage from './pages/AlbumPage';
import albumsService from './services/albumsService'

function App() {
    const [albumOfTheDay, setAlbumOfTheDay] = useState(null);
    const [isLoading, setIsLoading] = useState(true);

    const handleAlbumOfTheDay = (album) => {
        setAlbumOfTheDay(album);
        console.log(album);
    }

    useEffect(() => {
        const fetchAlbumOfTheDay = async () => {
            try {
                const fetchedAlbumOfTheDay = await albumsService.getAlbumOfTheDay();
                setAlbumOfTheDay(fetchedAlbumOfTheDay);
                setIsLoading(false);
            } catch (error) {
                console.error('Error fetching album of the day:', error);
                setIsLoading(false);
            }
        };

        // Fetch album of the day initially and then every 1 minute
        fetchAlbumOfTheDay();
        //const interval = setInterval(fetchAlbumOfTheDay, 60000); // 60000 ms = 1 minute as demonstration purposes

        //return () => clearInterval(interval); // Clean up interval on component unmount
    }, []);
    
    return (
        <Router>
            <Navbar />
            <Routes>
                <Route path="/" element={<HomePage albumOfDay={albumOfTheDay} isLoading={isLoading} />} />
                <Route path="/artists" element={<ArtistsPage albumOfTheDay={albumOfTheDay} setAlbumOfTheDay={handleAlbumOfTheDay} />} /> 
                <Route path="/artists/:artistId" element={<ArtistPage albumOfTheDay={albumOfTheDay} setAlbumOfTheDay={handleAlbumOfTheDay} />} />
                <Route path="/artists/:artistId/albums" element={<AlbumPage albumOfTheDay={albumOfTheDay} setAlbumOfTheDay={handleAlbumOfTheDay} />} />
                <Route path="/artists/:artistId/albums/:albumId" element={<AlbumPage albumOfTheDay={albumOfTheDay} setAlbumOfTheDay={handleAlbumOfTheDay} />} />
            </Routes>
       </Router>
    );
    
    
}

export default App;