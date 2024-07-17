import React, { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import { TextField, Autocomplete, CircularProgress } from '@mui/material';

const SearchBar = () => {
    const [searchTerm, setSearchTerm] = useState('');
    const [options, setOptions] = useState([]);
    const [loading, setLoading] = useState(false);
    const navigate = useNavigate();

    useEffect(() => {
        const fetchData = async () => {
            setLoading(true);
            try {
                const response = await fetch('/api/songs');
                if (!response.ok) {
                    throw new Error('Network response was not ok');
                }
                const data = await response.json();
                const processedOptions = preprocessOptions(data);
                setOptions(processedOptions);
                setLoading(false);
            } catch (error) {
                console.error('Error fetching songs:', error);
                setLoading(false);
            }
        };

        fetchData();
    }, []);

    const preprocessOptions = (data) => {
        const uniqueArtists = new Map();
        const uniqueAlbums = new Map();
        const uniqueSongs = new Map();

        // Collect unique artists, albums, and songs
        data.forEach(song => {
            uniqueArtists.set(song.artistId, song.artistName);
            uniqueAlbums.set(song.albumId, {
                artistId: song.artistId,
                artistName: song.artistName,
                albumId: song.albumId,
                albumName: song.albumName
            });
            uniqueSongs.set(song.songId, {
                artistId: song.artistId,
                artistName: song.artistName,
                albumId: song.albumId,
                albumName: song.albumName,
                songId: song.songId,
                title: song.title
            });
        });

        // Create options array combining artist, album, and song
        const optionsArray = [];

        uniqueArtists.forEach((artistName, artistId) => {
            optionsArray.push({ artistName, artistId });

            uniqueAlbums.forEach(album => {
                if (album.artistId === artistId) {
                    optionsArray.push({
                        artistName: artistName,
                        artistId: artistId,
                        albumName: album.albumName,
                        albumId: album.albumId
                    });
                }
            });

            uniqueSongs.forEach(song => {
                if (song.artistId === artistId) {
                    optionsArray.push({
                        artistName: artistName,
                        artistId: artistId,
                        albumName: song.albumName,
                        albumId: song.albumId,
                        songId: song.songId,
                        title: song.title
                    });
                }
            });
        });

        return optionsArray;
    };

    const handleSearchChange = (event, value) => {
        setSearchTerm(value);
    };

    const handleSelect = (event, value) => {
        if (value) {
            if (value.artistId && !value.albumId) {
                navigate(`/artists/${value.artistId}`);
            } else if (value.albumId) {
                navigate(`/artists/${value.artistId}/albums/${value.albumId}`);
            } else if (value.songId) {
                navigate(`/artists/${value.artistId}/albums/${value.albumId}`, { state: { highlightSongId: value.songId } });
            }
        }
    };

    const filterOptions = (options, { inputValue }) => {
        const filtered = options.filter(option => {
            if (option.artistName.toLowerCase().includes(inputValue.toLowerCase())) {
                return true;
            }
            if (option.albumName && option.albumName.toLowerCase().includes(inputValue.toLowerCase())) {
                return true;
            }
            if (option.title && option.title.toLowerCase().includes(inputValue.toLowerCase())) {
                return true;
            }
            return false;
        });

        return filtered.slice(0, 5); // Limit to at most 5 results
    };

    return (
        <div className="search-box">
            <Autocomplete
                freeSolo
                options={options}
                getOptionLabel={(option) => {
                    if (option.songId) {
                        return `${option.artistName} - ${option.title} (${option.albumName})`;
                    } else if (option.albumName) {
                        return `${option.artistName} - ${option.albumName}`;
                    } else {
                        return option.artistName;
                    }
                }}
                filterOptions={filterOptions}
                renderInput={(params) => (
                    <TextField
                        {...params}
                        label="Artist, Album, Song..."
                        variant="outlined"
                        onChange={(event) => handleSearchChange(event, params.inputProps.value)}
                        InputProps={{
                            ...params.InputProps,
                            endAdornment: (
                                <>
                                    {loading ? <CircularProgress color="inherit" size={20} /> : null}
                                    {params.InputProps.endAdornment}
                                </>
                            ),
                        }}
                    />
                )}
                onChange={handleSelect}
            />
        </div>
    );
};

export default SearchBar;
