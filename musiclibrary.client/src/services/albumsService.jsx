const API_BASE_URL = '/api/artists';

const albumsService = {

    getAlbumOfTheDay: async () => {
        try {
            const response = await fetch('/api/AlbumOfTheDay')
            if (!response.ok) {
                throw new Error('Failed to fetch album of the day.')
            }
            return response.json();
        } catch (error) {
            console.error('Error fetching album of the day: ', error);
            throw error;
        }
    },

    getAlbums: async () => {
        try {
            const response = await fetch('/api/AlbumsAll')
            if (!response.ok) {
                throw new Error('Failed to fetch albums.')
            }     
            return response.json();
        } catch (error) {
            console.error('Error fetching all albums: ', error);
            throw error;
        }
    },

    getAlbumsByArtistId: async (artistId) => {
        try {
            const response = await fetch(`${API_BASE_URL}/${artistId}/albums`);
            if (!response.ok) {
                throw new Error(`Failed to fetch albums for artist with ID ${artistId}`);
            }
            return response.json();
        } catch (error) {
            console.error(`Error fetching albums for artist with ID ${artistId}:`, error);
            throw error;
        }
    },

    getAlbumById: async (artistId, albumId) => {
        try {
            const response = await fetch(`${API_BASE_URL}/${artistId}/albums/${albumId}`);
            if (!response.ok) {
                throw new Error(`Failed to fetch album with ID ${albumId}`);
            }
            return response.json();
        } catch (error) {
            console.error(`Error fetching album with ID ${albumId}:`, error);
            throw error;
        }
    },

    createAlbum: async (artistId, albumData) => {
        try {
            const response = await fetch(`${API_BASE_URL}/${artistId}/albums`, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(albumData),
            });
            if (response.status === 201) {
                // Extract artistId from the location header
                const locationHeader = response.headers.get('location');
                if (!locationHeader) {
                    throw new Error('Location header missing in response.');
                }

                // Fetch the newly created artist using the location URL
                const artistResponse = await fetch(locationHeader);
                if (!artistResponse.ok) {
                    throw new Error('Failed to fetch newly created artist.');
                }

                const newArtist = await artistResponse.json();

                return { success: true, message: 'Artist created successfully.', artist: newArtist };
            }

            // Handle other responses
            if (!response.ok) {
                throw new Error('Failed to create artist');
            }

            const data = await response.json(); // Handle response body if needed
            return data;
        } catch (error) {
            console.error('Error creating album:', error);
            throw error;
        }
    },

    updateAlbum: async (artistId, albumId, albumData) => {
        try {
            const response = await fetch(`${API_BASE_URL}/${artistId}/albums/${albumId}`, {
                method: 'PATCH',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(albumData),
            });
            if (!response.ok) {
                throw new Error(`Failed to update album with ID ${albumId}`);
            }
            return response.json();
        } catch (error) {
            console.error(`Error updating album with ID ${albumId}:`, error);
            throw error;
        }
    },

    deleteAlbum: async (artistId, albumId) => {
        try {
            const response = await fetch(`${API_BASE_URL}/${artistId}/albums/${albumId}`, {
                method: 'DELETE',
            });
            if (!response.ok) {
                throw new Error(`Failed to delete album with ID ${albumId}`);
            }
        } catch (error) {
            console.error(`Error deleting album with ID ${albumId}:`, error);
            throw error;
        }
    },

    deleteAllAlbums: async (artistId) => {
        try {
            const response = await fetch(`${API_BASE_URL}/${artistId}/albums/delete`, {
                method: 'DELETE',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify({ artistId }),
            });
            if (!response.ok) {
                throw new Error(`Failed to delete albuma for ${artistId}`);
            }
        } catch (error) {
            console.error(`Error deleting albums for ${albumId}:`, error);
            throw error;
        }
    },
};

export default albumsService;
