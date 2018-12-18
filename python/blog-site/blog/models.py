from django.db import models
from django.contrib.auth.models import User

class Article(models.Model):
    title = models.CharField(max_length=100)
    subtitle = models.CharField(max_length=100)
    author = models.ForeignKey(User, on_delete=models.CASCADE)
    text = models.TextField()
    cover = models.ImageField(upload_to='uploads')
    publish_date = models.DateTimeField(auto_now=True)

    def __str__(self):
        return self.title

