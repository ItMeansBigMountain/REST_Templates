

# CRUD COMMANDS



import requests






# # DELETE
# for x in range(51 , 60 , 1 ):
#     url = 'http://localhost:4000/users/'+str(x)
#     r = requests.delete(url)
#     pprint.pprint(  r.json() )


url = 'http://localhost:4000/books/81'
r = requests.delete(url)
print(  r.json() )









# # POST
# url = 'http://localhost:4000/books'

# myobj = {
# 		"Title":  "sit Down",
# 		"Author": "life",
# 		"Desc":   "do things especially when you dont feel like it",
# 	}

# r = requests.post(url, json = myobj)
# print(r)






# PUT
# myobj = {
# 		"Title":  "stand up",
# 		"Author": "effort",
# 		"Desc":   "just because youre busy doesnt mean youre productive",
# 	}
# url = 'http://localhost:4000/books/81'
# r = requests.put(url=url, json = myobj)
# print(r.text)







# GET
# url = 'http://localhost:4000/users/'
# r = requests.get(url)
# pprint.pprint(  r.json() )



