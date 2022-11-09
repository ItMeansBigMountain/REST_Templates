from django.db import models
from datetime import datetime


class User(models.Model):
    id = models.AutoField(primary_key=True)
    name = models.CharField(max_length=50)
    password = models.CharField(max_length=50)
    email = models.EmailField( default=None )
    date_joined = models.DateTimeField(auto_now_add=True, blank=True)
    
    def __str__(self):
        if self.email: return f"{self.email} "
        else: return self.id

    def __repr__(self):
        return f"<User: {self.email}>"

