WebAPIService Contract

[[TOC]]

# Introduction

This document describes the operations on the logging service.

This service is a restful service.

The payload format of the service is JSON and only handle JSON data.

# Account Contract Actions

## Account

<table>
  <tr>
    <td>Field</td>
    <td>Type</td>
    <td>Description</td>
  </tr>
  <tr>
    <td>Id</td>
    <td>GUID</td>
    <td>ID of the account.</td>
  </tr>
  <tr>
    <td>Username</td>
    <td>string</td>
    <td>Email of the account</td>
  </tr>
  <tr>
    <td>Nickname</td>
    <td>string</td>
    <td>Nickname of the user</td>
  </tr>
  <tr>
    <td>Password</td>
    <td>string</td>
    <td>Hash of user's password</td>
  </tr>
  <tr>
    <td>Activated</td>
    <td>bool</td>
    <td>Bool to activate or deactivate user.</td>
  </tr>
</table>


## Create user

Method: POST - http://<Hostname>/api/account/

### Parameter

<table>
  <tr>
    <td>Field</td>
    <td>Type</td>
    <td>Description</td>
  </tr>
  <tr>
    <td>Account</td>
    <td>JSON object</td>
    <td>Account object with three fields: Username, Nickname, Password.</td>
  </tr>
</table>


## Response

### Success 200

<table>
  <tr>
    <td>Field</td>
    <td>Type</td>
    <td>Description</td>
  </tr>
  <tr>
    <td>userId</td>
    <td>string</td>
    <td>ID of the created user</td>
  </tr>
</table>


### Error 4xx

<table>
  <tr>
    <td>Status</td>
    <td>Field</td>
    <td>Description</td>
  </tr>
  <tr>
    <td>400 Bad Request</td>
    <td>errorMessage</td>
    <td>Incorrect parameters</td>
  </tr>
  <tr>
    <td>401 Unauthorized</td>
    <td>errorMessage</td>
    <td>Authentication failed.</td>
  </tr>
</table>


### Error 5xx

<table>
  <tr>
    <td>Status</td>
    <td>Field</td>
    <td>Description</td>
  </tr>
  <tr>
    <td>500 Internal Server Error</td>
    <td>errorMessage</td>
    <td>Internal server error</td>
  </tr>
</table>


## Get all users

Method: **GET **- http://<Hostname>/api/account

## Response

### Success 200

<table>
  <tr>
    <td>Field</td>
    <td>Type</td>
    <td>Description</td>
  </tr>
  <tr>
    <td>Accounts</td>
    <td>JSON</td>
    <td>List of all accounts</td>
  </tr>
</table>


### Error 4xx

<table>
  <tr>
    <td>Status</td>
    <td>Field</td>
    <td>Description</td>
  </tr>
  <tr>
    <td>401 Unauthorized</td>
    <td>errorMessage</td>
    <td>Authentication failed.</td>
  </tr>
</table>


### Error 5xx

<table>
  <tr>
    <td>Status</td>
    <td>Field</td>
    <td>Description</td>
  </tr>
  <tr>
    <td>500 Internal Server Error</td>
    <td>errorMessage</td>
    <td>Internal server error</td>
  </tr>
</table>


## Get a user

Method: Get - http://<Hostname>/api/account/{userId}

### Parameter

<table>
  <tr>
    <td>Field</td>
    <td>Type</td>
    <td>Description</td>
  </tr>
  <tr>
    <td>userId</td>
    <td>string(GUID)</td>
    <td>ID of the user.</td>
  </tr>
</table>


### Response

### Success 200

<table>
  <tr>
    <td>Field</td>
    <td>Type</td>
    <td>Description</td>
  </tr>
  <tr>
    <td>Account</td>
    <td>Json Object</td>
    <td>Account matching the userID.</td>
  </tr>
</table>


### Error 4xx

<table>
  <tr>
    <td>Status</td>
    <td>Field</td>
    <td>Description</td>
  </tr>
  <tr>
    <td>400 Bad Request</td>
    <td>errorMessage</td>
    <td>Incorrect parameters</td>
  </tr>
  <tr>
    <td>401 Unauthorized</td>
    <td>errorMessage</td>
    <td>Authentication failed.</td>
  </tr>
  <tr>
    <td>404 Not Found</td>
    <td>errorMessage</td>
    <td>Id not found.</td>
  </tr>
</table>


### Error 5xx

<table>
  <tr>
    <td>Status</td>
    <td>Field</td>
    <td>Description</td>
  </tr>
  <tr>
    <td>500 Internal Server Error</td>
    <td>errorMessage</td>
    <td>Internal server error</td>
  </tr>
</table>


## Update user

Method: Put- http://<Hostname>/api/account/{userId}

### Parameter

<table>
  <tr>
    <td>Field</td>
    <td>Type</td>
    <td>Description</td>
  </tr>
  <tr>
    <td>Account</td>
    <td>Object</td>
    <td>Account object with parameters to be changed.</td>
  </tr>
</table>


### Response

### Success 200

<table>
  <tr>
    <td>Field</td>
    <td>Type</td>
    <td>Description</td>
  </tr>
  <tr>
    <td>UserId</td>
    <td>string</td>
    <td>ID the user</td>
  </tr>
</table>


### Error 4xx

<table>
  <tr>
    <td>Status</td>
    <td>Field</td>
    <td>Description</td>
  </tr>
  <tr>
    <td>400 Bad Request</td>
    <td>errorMessage</td>
    <td>Incorrect parameters</td>
  </tr>
  <tr>
    <td>401 Unauthorized</td>
    <td>errorMessage</td>
    <td>Authentication failed.</td>
  </tr>
  <tr>
    <td>404 Not Found</td>
    <td>errorMessage</td>
    <td>Id not found.</td>
  </tr>
</table>


### Error 5xx

<table>
  <tr>
    <td>Field</td>
    <td>Description</td>
  </tr>
  <tr>
    <td>500 Internal Server Error</td>
    <td>Internal server error</td>
  </tr>
</table>


## Delete user

Method: Delete - http://<Hostname>/api/account/{userId}

### Parameter

<table>
  <tr>
    <td>Field</td>
    <td>Type</td>
    <td>Description</td>
  </tr>
  <tr>
    <td>userId</td>
    <td>GUID</td>
    <td>ID of the user.</td>
  </tr>
</table>


## Response

### Success 200

### Error 4xx

<table>
  <tr>
    <td>Status</td>
    <td>Field</td>
    <td>Description</td>
  </tr>
  <tr>
    <td>400 Bad Request</td>
    <td>errorMessage</td>
    <td>Incorrect parameters</td>
  </tr>
  <tr>
    <td>401 Unauthorized</td>
    <td>errorMessage</td>
    <td>Authentication failed.</td>
  </tr>
  <tr>
    <td>404 Not Found</td>
    <td>errorMessage</td>
    <td>Id not found.</td>
  </tr>
</table>


### Error 5xx

<table>
  <tr>
    <td>Status</td>
    <td>Field</td>
    <td>Description</td>
  </tr>
  <tr>
    <td>500 Internal Server Error</td>
    <td>errorMessage</td>
    <td>Internal server error</td>
  </tr>
</table>


# Storage Contract Actions

## Add a new data store

Method: POST - http://<Hostname>/api/storage/{userId}

### Parameter

<table>
  <tr>
    <td>Field</td>
    <td>Type</td>
    <td>Description</td>
  </tr>
  <tr>
    <td>userId</td>
    <td>GUID</td>
    <td>ID of the user.</td>
  </tr>
  <tr>
    <td>dataStoreName</td>
    <td>JSON</td>
    <td>Name of the datastore to be created.</td>
  </tr>
</table>


### Response

### Success 200

Successfully added.

<table>
  <tr>
    <td>Field</td>
    <td>Type</td>
    <td>Description</td>
  </tr>
  <tr>
    <td>ID</td>
    <td>string</td>
    <td>Return the created ID</td>
  </tr>
</table>


### Error 4xx

<table>
  <tr>
    <td>Status</td>
    <td>Field</td>
    <td>Description</td>
  </tr>
  <tr>
    <td>400 Bad Request</td>
    <td>errorMessage</td>
    <td>Incorrect parameters</td>
  </tr>
  <tr>
    <td>401 Unauthorized</td>
    <td>errorMessage</td>
    <td>Authentication failed.</td>
  </tr>
  <tr>
    <td>404 Not Found</td>
    <td>errorMessage</td>
    <td>Id not found.</td>
  </tr>
</table>


### Error 5xx

<table>
  <tr>
    <td>Status</td>
    <td>Field</td>
    <td>Description</td>
  </tr>
  <tr>
    <td>500 Internal Server Error</td>
    <td>errorMessage</td>
    <td>Internal server error</td>
  </tr>
</table>


## Add a new element

Method: POST - http://<Hostname>/api/storage/{userId}/{datastoreId}

### Parameter

<table>
  <tr>
    <td>Field</td>
    <td>Type</td>
    <td>Description</td>
  </tr>
  <tr>
    <td>userId</td>
    <td>GUID</td>
    <td>ID of the user.</td>
  </tr>
  <tr>
    <td>datastoreId</td>
    <td>string</td>
    <td>ID of the datastore.</td>
  </tr>
  <tr>
    <td>body</td>
    <td>JSON</td>
    <td>Content of the element.</td>
  </tr>
</table>


### Response

### Success 200

Successfully added.

<table>
  <tr>
    <td>Field</td>
    <td>Type</td>
    <td>Description</td>
  </tr>
  <tr>
    <td>ID</td>
    <td>string</td>
    <td>Return the created Id</td>
  </tr>
</table>


### Error 4xx

<table>
  <tr>
    <td>Status</td>
    <td>Field</td>
    <td>Description</td>
  </tr>
  <tr>
    <td>400 Bad Request</td>
    <td>errorMessage</td>
    <td>Incorrect parameters</td>
  </tr>
  <tr>
    <td>401 Unauthorized</td>
    <td>errorMessage</td>
    <td>Authentication failed.</td>
  </tr>
  <tr>
    <td>404 Not Found</td>
    <td>errorMessage</td>
    <td>Id not found.</td>
  </tr>
</table>


### Error 5xx

<table>
  <tr>
    <td>Status</td>
    <td>Field</td>
    <td>Description</td>
  </tr>
  <tr>
    <td>500 Internal Server Error</td>
    <td>errorMessage</td>
    <td>Internal server error</td>
  </tr>
</table>


## Get all data stores for a user

Method: **GET **- http://<Hostname>/api/storage/{userId}

### Parameter

<table>
  <tr>
    <td>Field</td>
    <td>Type</td>
    <td>Description</td>
  </tr>
  <tr>
    <td>userId</td>
    <td>GUID</td>
    <td>ID of the user.</td>
  </tr>
</table>


## Response

### Success 200

<table>
  <tr>
    <td>Field</td>
    <td>Type</td>
    <td>Description</td>
  </tr>
  <tr>
    <td>Data</td>
    <td>Json Object(s)</td>
    <td>Content of all data stores.</td>
  </tr>
</table>


### Error 4xx

<table>
  <tr>
    <td>Status</td>
    <td>Field</td>
    <td>Description</td>
  </tr>
  <tr>
    <td>400 Bad Request</td>
    <td>errorMessage</td>
    <td>Incorrect parameters</td>
  </tr>
  <tr>
    <td>401 Unauthorized</td>
    <td>errorMessage</td>
    <td>Authentication failed.</td>
  </tr>
  <tr>
    <td>404 Not Found</td>
    <td>errorMessage</td>
    <td>Id not found.</td>
  </tr>
</table>


### Error 5xx

<table>
  <tr>
    <td>Status</td>
    <td>Field</td>
    <td>Description</td>
  </tr>
  <tr>
    <td>500 Internal Server Error</td>
    <td>errorMessage</td>
    <td>Internal server error</td>
  </tr>
</table>


## Get a datastore for a user

Method: **GET **- http://<Hostname>/api/storage/{userId}/{datastoreId}

### Parameter

<table>
  <tr>
    <td>Field</td>
    <td>Type</td>
    <td>Description</td>
  </tr>
  <tr>
    <td>userId</td>
    <td>GUID</td>
    <td>ID of the user.</td>
  </tr>
  <tr>
    <td>datastoreId</td>
    <td>string</td>
    <td>ID of the datastore.</td>
  </tr>
</table>


### Response

### Success 200

<table>
  <tr>
    <td>Field</td>
    <td>Type</td>
    <td>Description</td>
  </tr>
  <tr>
    <td>Data</td>
    <td>Json Object(s)</td>
    <td>Content of all data stores.</td>
  </tr>
</table>


### Error 4xx

<table>
  <tr>
    <td>Status</td>
    <td>Field</td>
    <td>Description</td>
  </tr>
  <tr>
    <td>400 Bad Request</td>
    <td>errorMessage</td>
    <td>Incorrect parameters</td>
  </tr>
  <tr>
    <td>401 Unauthorized</td>
    <td>errorMessage</td>
    <td>Authentication failed.</td>
  </tr>
  <tr>
    <td>404 Not Found</td>
    <td>errorMessage</td>
    <td>Id not found.</td>
  </tr>
</table>


### Error 5xx

<table>
  <tr>
    <td>Status</td>
    <td>Field</td>
    <td>Description</td>
  </tr>
  <tr>
    <td>500 Internal Server Error</td>
    <td>errorMessage</td>
    <td>Internal server error</td>
  </tr>
</table>


## Get an element for a user

Method: **GET **- http://<Hostname>/api/storage/{userId}/{datastoreId}/data/{elementId}

### Parameter

<table>
  <tr>
    <td>Field</td>
    <td>Type</td>
    <td>Description</td>
  </tr>
  <tr>
    <td>userId</td>
    <td>GUID</td>
    <td>ID of the user.</td>
  </tr>
  <tr>
    <td>datastoreId</td>
    <td>string</td>
    <td>ID of the datastore.</td>
  </tr>
  <tr>
    <td>elementId</td>
    <td>string</td>
    <td>ID of the element.</td>
  </tr>
</table>


### Parameter

<table>
  <tr>
    <td>Field</td>
    <td>Type</td>
    <td>Description</td>
  </tr>
  <tr>
    <td>token</td>
    <td>Guid</td>
    <td>Authentication token</td>
  </tr>
</table>


### Response

### Success 200

<table>
  <tr>
    <td>Field</td>
    <td>Type</td>
    <td>Description</td>
  </tr>
  <tr>
    <td>Data</td>
    <td>Json Object(s)</td>
    <td>Content of the element.</td>
  </tr>
</table>


### Error 4xx

<table>
  <tr>
    <td>Status</td>
    <td>Field</td>
    <td>Description</td>
  </tr>
  <tr>
    <td>400 Bad Request</td>
    <td>errorMessage</td>
    <td>Incorrect parameters</td>
  </tr>
  <tr>
    <td>401 Unauthorized</td>
    <td>errorMessage</td>
    <td>Authentication failed.</td>
  </tr>
  <tr>
    <td>404 Not Found</td>
    <td>errorMessage</td>
    <td>Id not found.</td>
  </tr>
</table>


### Error 5xx

<table>
  <tr>
    <td>Status</td>
    <td>Field</td>
    <td>Description</td>
  </tr>
  <tr>
    <td>500 Internal Server Error</td>
    <td>errorMessage</td>
    <td>Internal server error</td>
  </tr>
</table>


## Update an element

Method: **PUT **- http://<Hostname>/api/storage/{userId}/{datastoreId}/data/{elementId}

### Parameter

<table>
  <tr>
    <td>Field</td>
    <td>Type</td>
    <td>Description</td>
  </tr>
  <tr>
    <td>userId</td>
    <td>GUID</td>
    <td>ID of the user.</td>
  </tr>
  <tr>
    <td>datastoreId</td>
    <td>string</td>
    <td>ID of the datastore.</td>
  </tr>
  <tr>
    <td>elementId</td>
    <td>string</td>
    <td>ID of the element.</td>
  </tr>
  <tr>
    <td>body</td>
    <td>JSON</td>
    <td>Updated content of the element.</td>
  </tr>
</table>


### Response

### Success 200

<table>
  <tr>
    <td>Field</td>
    <td>Type</td>
    <td>Description</td>
  </tr>
  <tr>
    <td>documentId</td>
    <td>string</td>
    <td>ID of the updated element.</td>
  </tr>
</table>


### Error 4xx

<table>
  <tr>
    <td>Status</td>
    <td>Field</td>
    <td>Description</td>
  </tr>
  <tr>
    <td>400 Bad Request</td>
    <td>errorMessage</td>
    <td>Incorrect parameters</td>
  </tr>
  <tr>
    <td>401 Unauthorized</td>
    <td>errorMessage</td>
    <td>Authentication failed.</td>
  </tr>
  <tr>
    <td>404 Not Found</td>
    <td>errorMessage</td>
    <td>Id not found.</td>
  </tr>
</table>


### Error 5xx

<table>
  <tr>
    <td>Status</td>
    <td>Field</td>
    <td>Description</td>
  </tr>
  <tr>
    <td>500 Internal Server Error</td>
    <td>errorMessage</td>
    <td>Internal server error</td>
  </tr>
</table>


## Remove all datastores

Method: **DELETE **- http://<Hostname>/api/storage/{userId}

### Parameter

<table>
  <tr>
    <td>Field</td>
    <td>Type</td>
    <td>Description</td>
  </tr>
  <tr>
    <td>userId</td>
    <td>GUID</td>
    <td>ID of the user.</td>
  </tr>
</table>


### Response

### Success 200

### Error 4xx

<table>
  <tr>
    <td>Status</td>
    <td>Field</td>
    <td>Description</td>
  </tr>
  <tr>
    <td>400 Bad Request</td>
    <td>errorMessage</td>
    <td>Incorrect parameters</td>
  </tr>
  <tr>
    <td>401 Unauthorized</td>
    <td>errorMessage</td>
    <td>Authentication failed.</td>
  </tr>
  <tr>
    <td>404 Not Found</td>
    <td>errorMessage</td>
    <td>Id not found.</td>
  </tr>
</table>


### Error 5xx

<table>
  <tr>
    <td>Status</td>
    <td>Field</td>
    <td>Description</td>
  </tr>
  <tr>
    <td>500 Internal Server Error</td>
    <td>errorMessage</td>
    <td>Internal server error</td>
  </tr>
</table>


## Remove a datastore

Method: **DELETE **- http://<Hostname>/api/storage/{userId}/{datastoreId}

### Parameter

<table>
  <tr>
    <td>Field</td>
    <td>Type</td>
    <td>Description</td>
  </tr>
  <tr>
    <td>userId</td>
    <td>GUID</td>
    <td>ID of the user.</td>
  </tr>
  <tr>
    <td>datastoreId</td>
    <td>string</td>
    <td>ID of the datastore.</td>
  </tr>
</table>


### Response

### Success 200

### Error 4xx

<table>
  <tr>
    <td>Status</td>
    <td>Field</td>
    <td>Description</td>
  </tr>
  <tr>
    <td>400 Bad Request</td>
    <td>errorMessage</td>
    <td>Incorrect parameters</td>
  </tr>
  <tr>
    <td>401 Unauthorized</td>
    <td>errorMessage</td>
    <td>Authentication failed.</td>
  </tr>
  <tr>
    <td>404 Not Found</td>
    <td>errorMessage</td>
    <td>Id not found.</td>
  </tr>
</table>


### Error 5xx

<table>
  <tr>
    <td>Field</td>
    <td>Description</td>
  </tr>
  <tr>
    <td>500 Internal Server Error</td>
    <td>Internal server error</td>
  </tr>
</table>


## Remove all elements

Method: **DELETE **- http://<Hostname>/api/storage/{userId}/{datastoreId}/data/

### Parameter

<table>
  <tr>
    <td>Field</td>
    <td>Type</td>
    <td>Description</td>
  </tr>
  <tr>
    <td>userId</td>
    <td>GUID</td>
    <td>ID of the user.</td>
  </tr>
  <tr>
    <td>datastoreId</td>
    <td>string</td>
    <td>ID of the datastore.</td>
  </tr>
</table>


## Response

### Success 200

### Error 4xx

<table>
  <tr>
    <td>Status</td>
    <td>Field</td>
    <td>Description</td>
  </tr>
  <tr>
    <td>400 Bad Request</td>
    <td>errorMessage</td>
    <td>Incorrect parameters</td>
  </tr>
  <tr>
    <td>401 Unauthorized</td>
    <td>errorMessage</td>
    <td>Authentication failed.</td>
  </tr>
  <tr>
    <td>404 Not Found</td>
    <td>errorMessage</td>
    <td>Id not found.</td>
  </tr>
</table>


### Error 5xx

<table>
  <tr>
    <td>Status</td>
    <td>Field</td>
    <td>Description</td>
  </tr>
  <tr>
    <td>500 Internal Server Error</td>
    <td>errorMessage</td>
    <td>Internal server error</td>
  </tr>
</table>


## Remove an element

Method: **DELETE **- http://<Hostname>/api/storage/{userId}/{datastoreId}/data/{elementId}

### Parameter

<table>
  <tr>
    <td>Field</td>
    <td>Type</td>
    <td>Description</td>
  </tr>
  <tr>
    <td>userId</td>
    <td>GUID</td>
    <td>ID of the user.</td>
  </tr>
  <tr>
    <td>datastoreId</td>
    <td>string</td>
    <td>ID of the datastore.</td>
  </tr>
  <tr>
    <td>elementId</td>
    <td>string</td>
    <td>ID of the element.</td>
  </tr>
</table>


## Response

### Success 200

### Error 4xx

<table>
  <tr>
    <td>Status</td>
    <td>Field</td>
    <td>Description</td>
  </tr>
  <tr>
    <td>400 Bad Request</td>
    <td>errorMessage</td>
    <td>Incorrect parameters</td>
  </tr>
  <tr>
    <td>401 Unauthorized</td>
    <td>errorMessage</td>
    <td>Authentication failed.</td>
  </tr>
  <tr>
    <td>404 Not Found</td>
    <td>errorMessage</td>
    <td>Id not found.</td>
  </tr>
</table>


### Error 5xx

<table>
  <tr>
    <td>Status</td>
    <td>Field</td>
    <td>Description</td>
  </tr>
  <tr>
    <td>500 Internal Server Error</td>
    <td>errorMessage</td>
    <td>Internal server error</td>
  </tr>
</table>


