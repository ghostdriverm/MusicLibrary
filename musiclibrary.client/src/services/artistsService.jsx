const API_BASE_URL = '/api/artists';

const artistsService = {
    getAllArtists: async () => {
        try {
            const response = await fetch(API_BASE_URL);
            if (!response.ok) {
                throw new Error('Failed to fetch artists');
            }
            return response.json();
        } catch (error) {
            console.error('Error fetching artists:', error);
            throw error;
        }
    },

    getArtistById: async (artistId) => {
        try {
            const response = await fetch(`${API_BASE_URL}/${artistId}`);
            if (!response.ok) {
                throw new Error(`Failed to fetch artist with ID ${artistId}`);
            }
            return response.json();
        } catch (error) {
            console.error(`Error fetching artist with ID ${artistId}:`, error);
            throw error;
        }
    },

    createArtist: async ({ name }) => {
        try {
            const response = await fetch(API_BASE_URL, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify({ name }), 
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
            console.error('Error creating artist:', error);
            throw error;
        }
    },


    updateArtist: async (artistId, artistData) => {
        try {
            const response = await fetch(`${API_BASE_URL}/${artistId}`, {
                method: 'PATCH',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(artistData),
            });
            if (!response.ok) {
                throw new Error(`Failed to update artist with ID ${artistId}`);
            }

            if (response.status === 204) {
                return {success: true, message: 'Artist updated successfully.'}
            }
        } catch (error) {
            console.error(`Error updating artist with ID ${artistId}:`, error);
            throw error;
        }
    },

    deleteArtist: async ({ artistId }) => {
        try {
            const response = await fetch(`${API_BASE_URL}/${artistId}`, {
                method: 'DELETE',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify({ artistId }), 
            });

            if (!response.ok) {
                throw new Error(`Failed to delete artist with ID ${artistId}`);
            }

            return { success: true, message: 'Artist deleted successfully.' };
        } catch (error) {
            console.error(`Error deleting artist with ID ${artistId}:`, error);
            throw error;
        }
    },
};

export default artistsService;
