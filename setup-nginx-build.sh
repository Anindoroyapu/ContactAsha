


# Create a new domain configuration file
cp setup-nginx-domain-demo-win.conf /etc/nginx/sites-available/admin.ashaa.xyz


# Create a symbolic link to the sites-enabled directory
sudo ln -s /etc/nginx/sites-available/admin.ashaa.xyz /etc/nginx/sites-enabled/

# Test nginx config
sudo nginx -t

# Restart the nginx server
sudo systemctl restart nginx



# Install SSL certificate
# sudo certbot --nginx -d admin.ashaa.xyz