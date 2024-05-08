# Issue Tracking

*Narrative*: Users can submit issues for themselves for supported software. They must provide an adequate description of the problem.

The response we need to send back after a successful issue submission has:

- The software the issue was related to.
- The user information
    - Their name, email address, phone number
- the description provided by the user
- The status of the issue (by default "Submitted", later (Microservices!) can be "Resolved", "Closed", etc.)

Users can see their list of submitted issues.

GET /users/a829289/issues
Authorization: 3893893

200 Ok

[


]

Support techs (just adding this for now) can see the issues
    - they can see ALL issues
    - they can see issues by status
    - they can see issues for a specific piece of software
    - they can see issues from a specific user


## We have to design:

- The resources (the URIs)
- The methods on those resources (GET, POST, PUT, DELETE, etc.)
- The representations (what they need to send, what we need to send).


Operation: Submit an Issue

Operands: 
User Stuff - reference
Software 
Description - from the user in the request.

GET /catalog

POST /user/issue-requests

{
    "description": "caught on fire"
}

201
Location: /user/issue-requests/3893893

{
    "description": ...
    "status": "Submitted"

}



POST /catalog/{id}/issues
Authorization: 3893893
Content-Type: application/json

{

      "description": "Busted",  
      
}


{
    "id": 93939,
    "description": "Thing is busted!",
    "user": "/users/839893893",
    "software": "/catalog/3983989893",
    "status": "Submitted"
}


2xx - what we want

401 - Every developer working with APIS already knows what this means.
403 - We know who you are, and we don't like you. (Forbidden)
404 - that resource doesn't exist.
Nit-picky nose punching land.
400 - Sorry, you couldn't tell by our documentation what we really wanted here.


500 - the worst (so bad we blew up, we suck!)

