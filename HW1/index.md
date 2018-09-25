---
title: Homework 1
layout: default
---
# Software Engineering Homework

## Homework 1

For this homework we are tasked to learn and apply our current fundamental knowledge of HTML, CSS, and Git. We are also tasked
to use bootstrap for help in creating a decent looking website. 

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

```html
<!DOCTYPE html> 

<HTML>
<head>
    <!--------------------------------bootstrap------------------------------------>
    
    <link rel ="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.37/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    
    <title> Homework 1</title>
    <!-------------------load  CSS file ----------------------------------------->
    <link rel="stylesheet" type="text/css" href="Style.css">
    </head>
     <body>
    
    <div class="header">
        <h1>Homework 1</h1>
        </div>
        <p>For this homework we are tasked to learn and apply our current fundamental knowledge of HTML, CSS, and Git. </p>
    
    
    
    
    
    </body>
    
</HTML>
```