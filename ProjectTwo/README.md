# CSHP330A
REST .NET Core Service Project II

Create a REST web service for a User object.

Submit a github url to your project.

Service Requirements:

    POST to add a user
    PUT {guid} to update a user
    GET to get all users
    GET {guid} to get a single user
    DELETE {guid} to delete a single user
    Create Postman requests for each action (export your requests and save it to the repo)
    You DO NOT need a database, you can store it internally in a List or Array.

The user object will contain:

    User Id (service or database auto-generated guid)
    User Email (required)
    User Password (required) store it in plain text or better yet hashed
    Created Date (service generated)
