from django.contrib import admin
from django.urls import path, include

urlpatterns = [
    path('admin/', admin.site.urls),
    # url(r'^api/haters$', views.hater_list),
    # url(r'^api/haters/(?P<pk>[0-9]+)$', views.hater_detail),
    path('api/', include('pyapi.urls'))
]
