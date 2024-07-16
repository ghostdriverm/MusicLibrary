export async function searchAlbum(artistName, albumTitle) {
    const query = `https://musicbrainz.org/ws/2/release/?query=artist:${encodeURIComponent(artistName)}+release:${encodeURIComponent(albumTitle)}&fmt=json`;

    try {
        const response = await fetch(query);
        if (!response.ok) {
            throw new Error('Failed to fetch album information');
        }
        const data = await response.json();
        return data.releases.map(release => release.id);
    } catch (error) {
        console.error('Error searching album:', error);
        return [];
    }
}

export async function fetchCoverArt(mbids) {
    for (const mbid of mbids) {
        const frontEndpoint = `https://coverartarchive.org/release/${mbid}/front-500`;
        const backEndpoint = `https://coverartarchive.org/release/${mbid}/back-500`;

        try {
            // Fetch front image
            const frontResponse = await fetch(frontEndpoint);
            if (!frontResponse.ok) {
                continue; // Skip to the next MBID if front cover not found
            }
            const frontImageUrl = frontResponse.url;

            // Fetch back image
            let backImageUrl = null;
            try {
                const backResponse = await fetch(backEndpoint);
                if (backResponse.ok) {
                    backImageUrl = backResponse.url;
                }
            } catch (backError) {
                console.error(`Error fetching back cover art for MBID ${mbid}:`, backError);
            }

            // If a front image is found, return the images
            const images = [{ image: frontImageUrl, type: 'Front' }];
            if (backImageUrl) {
                images.push({ image: backImageUrl, type: 'Back' });
            }
            return images;
        } catch (error) {
            console.error(`Error fetching cover art for MBID ${mbid}:`, error);
        }
    }

    // If no images are found, return null
    return null;
}
