# Playlist API

SE4458 Assignment 2, Group 2 (Playlist)

A REST API for managing a music playlist: add, edit, delete, search, sort, filter, favorite and reorder songs. There is no frontend. The API is documented and testable through Swagger.

## Links

- **Code:** https://github.com/begumbakan/PlaylistAPI
- **Deployment (Swagger):** https://se4458-playlistapi-begum-ama6ffebbuc8defw.swedencentral-01.azurewebsites.net/swagger/index.html

## Tech Stack

- ASP.NET Core Web API (.NET)
- In-memory data storage (no database)
- Swagger UI (Swashbuckle)
- Hosted on Azure App Service, deployed from GitHub

## Design

The project is split into layers:

- **Controllers** (`SongsController`, `PlaylistController`): receive HTTP requests, call the service and return the right status codes.
- **Services** (`PlaylistService`): all the logic, working on an in-memory `List<Song>`.
- **Models**: the `Song` entity, request classes (`CreateSongRequest`, `UpdateSongRequest`, `MoveSongRequest`) and the `PlaylistSummary` response.

### Endpoints

| Method | URL | Description |
|---|---|---|
| GET | `/api/v1/playlist/summary` | Song count and total duration (for example "17 min 26 sec") |
| GET | `/api/v1/songs` | List songs. Optional filtering parameters: `search` (title, artist or album), `genre`, `sortBy` (`title`, `artist`, `duration`) and `order` (`asc`, `desc`). Defaults to playlist order. |
| POST | `/api/v1/songs` | Add a song (201 Created) |
| GET | `/api/v1/songs/{id}` | Get one song (404 if not found) |
| DELETE | `/api/v1/songs/{id}` | Remove a song (204 No Content) |
| PUT | `/api/v1/songs/{id}` | Edit a song |
| PUT | `/api/v1/songs/{id}/favorite` | Mark as favorite |
| DELETE | `/api/v1/songs/{id}/favorite` | Remove from favorites |
| PUT | `/api/v1/songs/{id}/position` | Change a song's position in the playlist |

Favorite uses PUT and DELETE instead of a toggle.

## Assumptions

- The playlist starts with 5 seeded songs, taken from the example screen.
- All data is stored in memory, as the assignment requires. It resets when the app restarts.
- Duration is stored in seconds and the summary text is calculated from it.
- Positions are always 1 to n with no gaps. They are renumbered after a delete or a reorder.
- `Id`, `Position` and `IsFavorite` are set by the server, not by the client.
- Search is case-insensitive and matches part of the title, artist or album.

## Issues Encountered

- **GitHub Actions deployment setup:** Deployment Center failed with an OIDC token error and then a "role assignment already exists" error. I fixed it by using Basic authentication instead.
- **Long Azure hostname:** the app URL has a random suffix because Azure uses unique default hostnames. The short URL I expected did not exist.
- **Swagger in .NET 10:** the newer Web API template has no Swagger UI by default, so I added Swashbuckle.

## Running Locally

```
dotnet run
```

Then open `/swagger` on the URL shown in the terminal.