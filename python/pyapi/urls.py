from django.conf.urls import url
from django.urls import path, include
from rest_framework_swagger.views import get_swagger_view

from . import views

schema_view = get_swagger_view(title='Python API')

urlpatterns = [

]
urlpatterns = [
    url(r'^$', schema_view),
    path('haters/', views.hater_list),
    path('haters/<int:pk>/', views.hater_detail),
    path('reasons/', views.reason_list),
    path('reasons/<int:pk>/', views.reason_detail),
    path('rest-auth/', include('rest_auth.urls')),
    url('^rest-auth/registration/', include('rest_auth.registration.urls'))
]
