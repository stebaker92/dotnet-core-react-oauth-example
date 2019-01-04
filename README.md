# Dotnet Core & React Google OAuth Example

A React (& Redux) app demoing Google / OAuth login, with a dotnet core backend generating JWT's

## Setup
- Clone this repo
- Setup a Project & Client in the Google Console
  - Add Google+ API AND Analytics API
  - Add Authorized JavaScript origins (i.e. `http://localhost:3000`)
  - Add Authorized redirect URIs (i.e. the google route of the backend - something like `https://localhost:44332/api/v1/auth/google`)
- Add `ClientId` to the react app (in config.js) & update the port (and protocol) for the base url 
- Add `ClientId`, `Secret` and `JwtSecret` (generate a long / secure secret!) to the backend (appSettings.json)

## Resources

[Decode JWT's in the browser](https://jwt.io/)
[Original Blog post](https://medium.com/mickeysden/react-and-google-oauth-with-net-core-backend-4faaba25ead0)
