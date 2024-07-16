![image](https://github.com/user-attachments/assets/268fbe8c-5a29-48f0-aa2a-f7743f6b25b9)# MusicLibrary

This is a .NET 8.0 web API with a React frontend application for managing a digital album collection, following the principles of Clean Architecture.

##Project Structure

- `src/MusicLibrary.WebAPI`: The main API project. This is the entry point of the application.
- `src/MusicLibrary.Application`: Contains the application logic. This layer is responsible for the application's behavior and policies.
- `src/MusicLibrary.Domain`: Contains enterprise logic and types. This is the core layer of the application.
- `src/MusicLibrary.Infrastructure`: Contains infrastructure-related code such as database and file system interactions. This layer supports the higher layers.
- `tests/MusicLibrary.client`: Contains the client side of the application (React SPA).

## Packages and Libraries

This project uses several NuGet packages and libraries to achieve its functionality:

###Backend

- **MediatR**: This library is used to implement the Command Query Responsibility Segregation (CQRS) pattern. In this solution, commands (which change the state of the system) and queries (which read the state) are separated for clarity and ease of development.

- **Entity Framework**: This is an open-source ORM framework for .NET. It enables developers to work with data using objects of domain-specific classes without focusing on the underlying database tables and columns where this data is stored.

- **AutoMapper**: This is a library is used to implement an object-object mapper.

###Frontend

- **Material UI**: This library contains foundational React UI component libraries used for different functionalities.

- **React-Three-Fiber**: This is a React renderer for threejs. It allows the application to render 3D objects.

- **React-Three/Drei**: This is a library which has a collection of helpers for the 3D renders.
  
- **react-router-dom**: The react-router-dom package contains bindings for using React Router in web applications. It allows to use navigation between pages. 

Please refer to the official documentation of each package for more details and usage examples.

## Getting Started

### Prerequisites

- .NET 8.0
- Visual Studio 2022 or later
- SSMS

### Building

To build the project, open the `MusicLibrary.sln` file in Visual Studio and build the solution.

### Running

To run the project, set `MusicLibrary.WebAPI` and `MusicLibrary.client` as the startup projects in Visual Studio and start the application.
## Database diagram
   - The database is structured as in the image:
![image](https://github.com/user-attachments/assets/dd1880a7-6ceb-4c2f-b94e-b7e622e0de3c)

   - A artist can have many albums.
   - A album can have only one artist.
   - An album can have many songs.
   - A song can have only one album.
     
## API Endpoints

### Album Of The Day endpoint

1. `GET /api/albumOfTheDay`

### All Albums endpoint

1. `GET /api/AlbumsAll`
 
### Artists endpoints

1. `POST /api/artists`
   - Body: JSON object with properties: `Name`

2. `GET /api/artists`

3. `GET /api/artists/{artistId}`
   - Parameters: `artistId`

4. `PATCH /api/artists/{artistId}`
   - Parameters: `artistId`
   - Body: JSON object with properties: `Name`
     
5. `DELETE /api/artists/{artistId}`
   - Parameters: `artistId`
 
   
### Albums endpoints

1. `POST /api/artists/{artistId}/Albums`
   - Parameters: `artistId`
   - Body: JSON object with properties: `Title`, `Description`
     
2. `GET /api/artists/{artistId}/Albums`
   - Parameters: `artistId`

3. `GET /api/artists/{artistId}/Albums/{albumId}`
   - Parameters: `artistId`, `albumId`

4. `PATCH /api/artists/{artistId}/Albums/{albumId}`
   - Parameters: `artistId`, `albumId`
   - Body: JSON object with properties `Title`, `Description`

5. `DELETE /api/artists/{artistId}/Albums/{albumId}`
   - Parameters: `artistId`, `albumId`
     
6. `DELETE /api/artists/{artistId}/Albums/delete`
   - Parameters: `artistId`

7. `POST /api/restaurants`
   - Body: JSON object with properties `Name`, `Description`, `Category`, `HasDelivery`, `ContactEmail`, `ContactNumber`, `City`, `Street`
   - Authorization: Bearer token

### Songs endpoints

1. `POST /api/artists/{artistId}/Albums/{albumId}/songs`
   - Parameters: `artistId`, `albumId`
   - Body: JSON object with properties: `Title`, `Length`
     
2. `GET /api/artists/{artistId}/Albums/{albumId}/songs`
   - Parameters: `artistId`, `albumId`

3. `GET /api/songs`
   - Parameters: no parameteres

4. `GET /api/artists/{artistId}/songs`
   - Parameters: `artistId`

4. `PATCH /api/artists/{artistId}/Albums/{albumId}/songs/{songId}`
   - Parameters: `artistId`, `albumId`, `songId`
   - Body: JSON object with properties `Title`, `Length`

5. `DELETE /api/artists/{artistId}/Albums/{albumId}/songs/{songId}`
   - Parameters: `artistId`, `albumId`, `songId`
     
6. `DELETE /api/artists/{artistId}/Albums/{albumId}/songs/delete`
   - Parameters: `artistId`


## Fontend

### Home Page

  - This is the landing page.
  - Here the user can see the album of the day, which is a 3D Rendered album of a random fetched artist (for demonstration purposes).
  - There is also a grid of featured albums which are taken from the database.

### Artists Page

  - This page allows the user to delete/update the artists as well as to create them.
  - It displays a list of current artists.

### Artist Page

  - This page allows the user to delete/update the artist.
  - This page allows the user to delete albums.
  - It displays a list of the artist's albums.
  - This page allows the user to add a new album for that artist.

### Album Page

  - This page allows the user to delete/update the songs in that album.
  - It displays a list of the album's songs.
  - This page allows the user to add new songs for that album.

### SearchBar

  - This element allows the user to search the Artist/Album/Song by giving autocomplete suggestions.
  - If the user clicks on that suggestion the application forwards the user to the specific page.
