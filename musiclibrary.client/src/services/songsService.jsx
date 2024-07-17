const API_BASE_URL = '/api/artists'

const songsService = {

    getAllSongs: async () => {
        try {
            const response = await fetch(`/api/songs`);
            if (!response.ok) {
                throw new Error("Failed to fetch all songs");
            }
            return response.json();
        } catch (errror) {
            console.error("Error fetching all songs : ", error);
            throw error;
        }
    },

    getSongsByAlbumId: async (artistId, albumId) => {
        try {
            const response = await fetch(`${API_BASE_URL}/${artistId}/albums/${albumId}/songs`);
            if (!response.ok) {
                throw new Error(`Failed to fetch songs for album with ID ${albumId}`);
            }
            return response.json();
        } catch (error) {
            console.error(`Error fetching songs for album with ID ${albumId}:`, error);
            throw error;
        }
    },

    getAllSongsByArtistId: async (artistId) => {
        try {
            const response = await fetch(`${API_BASE_URL}/${artistId}/songs`);
            if (!response.ok) {
                throw new Error(`Failed to fetch songs for album with ID ${albumId}`);
            }
            return response.json();
        } catch (error) {
            console.error(`Error fetching songs for album with ID ${albumId}:`, error);
            throw error;
        }
    },

    createSong: async (artistId, albumId, songData) => {
        try {
            const response = await fetch(`${API_BASE_URL}/${artistId}/albums/${albumId}/songs`, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(songData),
            });
            if (response.status === 201) {
                // Extract songId from the location header
                const locationHeader = response.headers.get('location');
                if (!locationHeader) {
                    throw new Error('Location header missing in response.');
                }

                // Fetch the newly created artist using the location URL
                const songResponse = await fetch(locationHeader);
                if (!songResponse.ok) {
                    throw new Error('Failed to fetch newly created artist.');
                }

                const newSong = await songResponse.json();

                return { success: true, message: 'Song created successfully.', song: newSong };
            }

            // Handle other responses
            if (!response.ok) {
                throw new Error('Failed to create artist');
            }

            const data = await response.json(); // Handle response body if needed
            return data;
        } catch (error) {
            console.error('Error creating song:', error);
            throw error;
        }
    },

    updateSong: async (artistId, albumId, songId, songData) => {
        try {
            const response = await fetch(`${API_BASE_URL}/${artistId}/albums/${albumId}/songs/${songId}`, {
                method: 'PATCH',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(songData),
            });
            if (!response.ok) {
                throw new Error(`Failed to update song with ID ${songId}`);
            }
            if (response.status === 204) {
                return { success: true, message: 'Song updated successfully.' }
            }
        } catch (error) {
            console.error(`Error updating song with ID ${songId}:`, error);
            throw error;
        }
    },

    deleteSong: async (artistId, albumId, songId) => {
        try {
            const response = await fetch(`${API_BASE_URL}/${artistId}/albums/${albumId}/songs/${songId}`, {
                method: 'DELETE',
            });
            if (!response.ok) {
                throw new Error(`Failed to delete song with ID ${songId}`);
            }
            const updatedAlbumResponse = await fetch(`${API_BASE_URL}/${artistId}/albums/${albumId}`);
            if (!updatedAlbumResponse.ok) {
                throw new Error('Failed to fetch updated album info');
            }
            const updatedAlbumInfo = await updatedAlbumResponse.json();
            return updatedAlbumInfo;
        } catch (error) {
            console.error(`Error deleting song with ID ${songId}:`, error);
            throw error;
        }
    },

    deleteAllSongs: async (artistId, albumId) => {
        try {
            const response = await fetch(`${API_BASE_URL}/${artistId}/albums/${albumId}/songs/delete`, {
                method: 'DELETE',
                headers: {
                    'Content-Type': 'application/json',
                },
            });
            if (!response.ok) {
                throw new Error(`Failed to delete songs for album Id ${albumId}`);
            }
            const albumInfo = await fetch(`${API_BASE_URL}/${artistId}/albums/${albumId}`);
            return albumInfo;
        } catch (error) {
            console.error(`Error deleting songs for album ID ${albumId}:`, error);
            throw error;
        }
    },
};

export default songsService;
