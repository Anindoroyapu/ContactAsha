# Bash

# Git pull
git pull

# Build the image force
docker build -t ContactFormApi . #--no-cache

# Run the docker
docker rm -f api
docker run -d --name api -p 5050:5050 ContactFormApi


# Publish on Live
# ssh -i "C:\Users\anind\Downloads" anindo@20.198.240.113

# Published on Testing
# ssh -i "C:\Users\anind\Downloads" anindo@20.198.240.113