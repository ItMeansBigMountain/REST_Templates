

# CRUD COMMANDS



import requests






# # DELETE
# for x in range(51 , 60 , 1 ):
#     url = 'http://127.0.0.1:8000/users/'+str(x)
#     r = requests.delete(url)
#     pprint.pprint(  r.json() )


# url = 'http://127.0.0.1:8000/users/1'
# r = requests.delete(url)
# print(  r.json() )









# # POST

# url = 'http://127.0.0.1:8000/users'

# myobj = {
#      "name" : "test",
#      "email" : "java@coding.com",
#  }

# for x in range(0,3,1):
#      myobj['title'] = '===' * x
#      myobj['instructor'] = myobj['instructor']
#      r = requests.post(url, json = myobj)

# r = requests.post(url, json = myobj)
# print(r)






# PUT
# myobj = {
#     "id" : "1",
#     "name" : "james",
#     "email" : "gozzling@java.com",
# }
# url = 'http://127.0.0.1:8000/users'
# r = requests.put(url=url, json = myobj)
# print(r.text)







# GET
# url = 'http://127.0.0.1:8000/users/'
# r = requests.get(url)
# pprint.pprint(  r.json() )






# SEND EMAIL
url = 'http://localhost:8000/sendmail?to=laflametoast@gmail.com&subject=nice%20work&body=im%20very%20happy%20with%20my%20work'
r = requests.get(url)
print(  r.text )
