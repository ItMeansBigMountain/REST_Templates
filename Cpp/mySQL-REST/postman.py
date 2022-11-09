import requests



# POST

myobj = {
    "name":"Sosai",
    "size":"Large",
    "wins":50
}

data = requests.post(url="http://www.localhost:5000/add",json=myobj ).json()