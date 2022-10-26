
# ****************************
# REQUIREMENTS
    # pip3 install flask
    # pip3 install Flask-SQLAlchemy
    # pip3 install Flask-marshmallow
    # pip3 install marshmallow-sqlalchemy
# ****************************


import json

from flask import Flask , request , jsonify
from flask_sqlalchemy import SQLAlchemy 
from flask_marshmallow import Marshmallow

import time
from datetime import datetime

from os.path import exists









# INIT FLASK VARIABLES
app = Flask(__name__)
app.config["DEBUG"] = True


# INIT SQL VARIABLES
app.config['SQLALCHEMY_DATABASE_URI'] = "sqlite:///db.sqlite3"
app.config['SQLALCHEMY_TRACK_MODIFICATIONS'] = False

db = SQLAlchemy(app)
ma = Marshmallow(app)









# ************************** database uri ********************************

# dialect://username:password@host:port/Schema_Name

# EXAMPLES:

    # # SQLite
    # sqlite:///project.db


    # # PostgreSQL
    # postgresql://scott:tiger@localhost/Schema_Name


    # # MySQL / MariaDB
    # mysql://scott:tiger@localhost/Schema_Name

# ************************************************************************









# SQL TABLE MODELS
class User(db.Model):
    id = db.Column( db.Integer, primary_key=True   )
    name = db.Column( db.String(50)   )
    email = db.Column( db.String(50) , unique=True   )
    date_joined = db.Column( db.Date , default=datetime.utcnow   )

    def __repr__(self):
        return f"<User: {self.email}>"






# SQL TABLE SERIALIZATION CLASSES
class UserSchema(ma.SQLAlchemyAutoSchema):
    class Meta:
        model = User










# SQLITE3 DB FILE CHECK
if app.config['SQLALCHEMY_DATABASE_URI'].split(":")[0] == "sqlite":
    if not exists("db.sqlite3"):
        print("Creating SQLite file in 'main.py' directory")
        db.create_all()
    else:
        print("Database File Already Exists!")



















# ENDPOINTS
@app.route('/users', methods=['GET'])
def query_users():

    if request.args.get("email") != None:
        data = User.query.filter_by(email=request.args.get("email")).first()
        users_schema = UserSchema()
        output = users_schema.dump(data)
        return jsonify(output)

    elif request.args.get("id")  != None :
        data = User.query.get(request.args.get("id"))
        users_schema = UserSchema()
        output = users_schema.dump(data)
        return jsonify(output)

    else:
        data = User.query.all()
        users_schema = UserSchema(many=True)
        output = users_schema.dump(data)
        return jsonify(output)











@app.route('/users/<pk>', methods=['GET'])
def query_user(pk):
    data = User.query.get(pk)
    users_schema = UserSchema()
    output = users_schema.dump(data)
    return jsonify(output)












@app.route('/users/<pk>', methods=['PUT'])
def update_users(pk):

    print(request.args)

    if "name" in request.args.keys() and "email" in request.args.keys():
    # if request.args.get("name")  != None and request.args.get("email")  != None :
        data = User.query.get(request.args.get("id"))
        
        data['name'] = request.args['name']
        data['email'] = request.args['email']

        db.session.commit()

        users_schema = UserSchema()
        output = users_schema.dump(data)
        return jsonify(output)


    return jsonify( {"ERROR" : 'Please Enter all attributes: ["name" , "email"] '} )







@app.route('/users', methods=['POST'])
def update_record():
    record = json.loads(request.data)
    
    entry = User(name=record.get("name") , email=record.get("email"))
    db.session.add(entry)
    db.session.commit()

    return jsonify(record)

    


@app.route('/users/<pk>', methods=['DELETE'])
def delete_record(pk):
    data = User.query.get(pk)
    db.session.delete(data)
    db.session.commit()

    return jsonify({"deleted_id":pk})

    
























# @app.route('/', methods=['DELETE'])
# def delte_record():
#     record = json.loads(request.data)
#     new_records = []
#     with open('/tmp/data.txt', 'r') as f:
#         data = f.read()
#         records = json.loads(data)
#         for r in records:
#             if r['name'] == record['name']:
#                 continue
#             new_records.append(r)
#     with open('/tmp/data.txt', 'w') as f:
#         f.write(json.dumps(new_records, indent=2))
#     return jsonify(record)














# RUN SERVER
# app.run(host="0.0.0.0")
app.run()