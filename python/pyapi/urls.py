from django.conf.urls import url
from django.urls import path, include

from pyapi.views import HaterRepositoryFactory
from . import views

urlpatterns = [
    path('haters/', views.HaterList.as_view(hater_repository_factory=HaterRepositoryFactory)),
    path('haters/<int:pk>/', views.HaterDetail.as_view()),
    path('reasons/', views.reason_list),
    path('reasons/<int:pk>/', views.reason_detail),

    path('rest-auth/', include('rest_auth.urls')),
    url('^rest-auth/registration/', include('rest_auth.registration.urls'))
]
