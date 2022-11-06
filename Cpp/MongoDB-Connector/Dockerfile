FROM evanugarte/mongocxx-base

WORKDIR /example

RUN apt-get update --allow-releaseinfo-change && apt-get install -y wget cmake git make g++ curl python3 

COPY include include/

COPY src src/

COPY makefile makefile

RUN mkdir /example/bin; exit 0

RUN make all


CMD ["./bin/main"]