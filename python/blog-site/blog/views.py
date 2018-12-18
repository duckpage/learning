from django.shortcuts import render, Http404

from blog.models import Article

def home(request):
    articles = Article.objects.all().order_by('-publish_date')
    return render(request, 'blog/home.html', {
        'articles': articles
    })


def article(request, code):
    try:
        article = Article.objects.get(pk=code)
        return render(request, 'blog/article.html', {
            'article': article
        })
    except Article.DoesNotExist:
        raise Http404()