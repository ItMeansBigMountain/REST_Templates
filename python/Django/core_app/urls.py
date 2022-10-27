from django.urls import path
from django.http import HttpResponse , JsonResponse
from . import views
from requests import get
from json import load


urlpatterns = [
    path("" , lambda request : HttpResponse("welcome!") ),
    path("users" , views.query_users ),
    path("users/<int:pk>" , views.query_user ),
]

