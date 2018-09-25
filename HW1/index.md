---
title: Homework 1
layout: default
---
# Software Engineering Homework

## Homework 1

For this homework we are tasked to learn and apply our current fundamental knowledge of HTML, CSS, and Git. We are also tasked
to use bootstrap for help in creating a decent looking website. Below are the following links to the assignment, repository, and the demo of the website.

1. [Assignment](http://www.wou.edu/~morses/classes/cs46x/assignments/HW1.html)
2. [Repository](https://github.com/ABergman7/ABergman7.github.io)


### Git

Our first task was to setup a git profile, and then setting up our repository. From there, we then downloaded the git command line
and then cloned our repository to our machine. The following is the code for the setup on the current system.

```bash

cd Desktop/HW460
mkdir repos
cd repos
git clone https://github.com/ABergman7/ABergman7.github.io.git
cd ABergman7.github.io

git config --global user.email "abergman15@wou.edu"
git config --global user.name "ABergman7"
```

After setup I added a "hello world" echo to the index.html folder. I eventually edited it, but for now I just wanted to push my initial commit.

```bash
echo "Hello World" > index.html
git add --all
git commit -m "Initial commit"
git push -u origin master
```

### HTML
#### Bootstrap
```html
<!DOCTYPE html> 
<html lang= "en">

<head>
    <title>Austin Bergman</title>
    <!--------------------------------bootstrap------------------------------------>
    
    <!-- Latest compiled and minified CSS -->
    <link rel ="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.37/css/bootstrap.min.css">
    
    <!-- jQuery library -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    
    <!-- Latest compiled JavaScript -->
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    
    
    <!------------------- CSS ----------------------------------------->
    <link rel="stylesheet" type="text/css" href="Style.css">
    
```
After loading bootstrap 

