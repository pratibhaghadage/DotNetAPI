# DotNetAPI
This API provides the ability to manage contacts by sending an REST/HTTP request to the server. 
This API’s functionality is useful for applications that need to administer contacts from anywhere

 URL
https://contactmanagementapi2.azurewebsites.net/api/contacts

Method:
<The request type>

GET | POST | DELETE | PUT

URL Params
Request Type	URL
GET         	https://contactmanagementapi2.azurewebsites.net/api/contacts
              https://contactmanagementapi2.azurewebsites.net/api/contact/2
POST	        https://contactmanagementapi2.azurewebsites.net/api/contacts
PUT         	https://contactmanagementapi2.azurewebsites.net/api/contacts/2
DELETE	      https://contactmanagementapi2.azurewebsites.net/api/contacts/2


Success Response:
Code: 200
Content: { id : 12 }

Error Response:
code 401, 500

Sample Javascript call to api
$.ajax({
        url: 'https://contactmanagementapi2.azurewebsites.net/api/contacts',
        contentType: "application/json",
        dataType: 'json',
        success: function(result){
            console.log(result);
        }
    })

 
For any assistance/support mailto: pratibhaghadage@gmail.com
