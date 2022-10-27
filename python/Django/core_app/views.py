from django.shortcuts import render
from django.http  import JsonResponse
from rest_framework.parsers import JSONParser
from rest_framework.decorators import api_view
from rest_framework.response import Response 
from rest_framework import status 


from .models import User
from .serializers import User_Serializer





# ROUTE: "/users"
@api_view(['GET', 'POST'])
def query_users(request):

    if request.method == "GET":
        users = User.objects.all()
        serializer = User_Serializer(users , many=True)
        return Response( serializer.data  )

    elif request.method == "POST":
        serializer =  User_Serializer(data=request.data) 

        if serializer.is_valid():
            serializer.save()
            return Response( request.data , status=status.HTTP_201_CREATED )
        else:
            print(serializer.errors)
            return Response(serializer.errors , status=status.HTTP_401_UNAUTHORIZED)






# ROUTE: "/users/<int:pk>"
@api_view(['GET', 'PUT' , 'DELETE'])
def query_user(request , pk):
    # VALIDATE request
    try:
        q_user = User.objects.filter(id=pk).last()
    except Stock_ticker.DoesNotExist:
        return Response(status=status.HTTP_400_BAD_REQUEST)
    except Exception as e:
        return Response( str(e) ,status=status.HTTP_404_NOT_FOUND)
    

    if request.method == "GET":
        serializer = User_Serializer(q_user)
        return Response(serializer.data , status=status.HTTP_200_OK)
    

    elif request.method == "PUT":
        serializer =  User(q_user , data = request.data) 
        # VALIDATE serialization
        if serializer.is_valid():
            serializer.save()
            return Response( serializer.data , status=status.HTTP_201_CREATED)
        else:
            print(serializer.errors)
            return Response(serializer.errors , status=status.HTTP_406_NOT_ACCEPTABLE)


    elif request.method == "DELETE":
        q_user.delete()
        return Response(status=status.HTTP_202_ACCEPTED)
