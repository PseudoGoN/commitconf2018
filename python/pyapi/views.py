from django.db.models import QuerySet
from django.http import Http404
from rest_framework import status
from rest_framework.decorators import api_view
from rest_framework.request import Request
from rest_framework.response import Response
from rest_framework.views import APIView

from pyapi.models import Hater, Reason
from pyapi.serializers import HaterSerializer, ReasonSerializer


class Repository(object):

    def __init__(self, model: type):
        self.model = model

    def get_all_haters(self) -> QuerySet:
        return self.model.objects.all()

    def get_hater_by_id(self, id):
        return self.model.get(pk=id)


class HaterRepositoryFactory(object):

    @staticmethod
    def create():
        return Repository(Hater)


class HaterList(APIView):
    """
    List all code haters, or create a new hater.
    """
    hater_repository_factory = None

    def get(self, _) -> Response:
        """
        List all haters
        """
        haters = self.hater_repository_factory.create().get_all_haters()
        serializer = HaterSerializer(haters, many=True)
        return Response(serializer.data)

    def post(self, request: Request) -> Response:
        serializer = HaterSerializer(data=request.data)
        if serializer.is_valid():
            serializer.save()
            return Response(serializer.data, status=status.HTTP_201_CREATED)
        return Response(serializer.errors, status=status.HTTP_400_BAD_REQUEST)


class HaterDetail(APIView):
    """
        Retrieve, update or delete a code hater.
    """
    def get_object(self, pk):
        try:
            return Hater.objects.get(pk=pk)
        except Hater.DoesNotExist:
            raise Http404

    def get(self, request, pk, format=None):
        hater = self.get_object(pk)
        serializer = HaterSerializer(hater)
        return Response(serializer.data)

    def put(self, request, pk, format=None):
        hater = self.get_object(pk)
        serializer = HaterSerializer(hater, data=request.data)
        if serializer.is_valid():
            serializer.save()
            return Response(status=status.HTTP_204_NO_CONTENT)
        return Response(serializer.errors, status=status.HTTP_400_BAD_REQUEST)

    def delete(self, request, pk, format=None):
        hater = self.get_object(pk)
        hater.delete()
        return Response(status=status.HTTP_204_NO_CONTENT)


@api_view(['GET', 'POST'])
def reason_list(request):
    """
    List all code reasons, or create a new reason.
    """
    if request.method == 'GET':
        reasons = Reason.objects.all()
        serializer = ReasonSerializer(reasons, many=True)
        return Response(serializer.data)

    elif request.method == 'POST':
        serializer = ReasonSerializer(data=request.data)
        if serializer.is_valid():
            serializer.save()
            return Response(serializer.data, status=status.HTTP_201_CREATED)
        return Response(serializer.errors, status=status.HTTP_400_BAD_REQUEST)


@api_view(['GET', 'PUT', 'DELETE'])
def reason_detail(request, pk):
    """
    Retrieve, update or delete a code reason.
    """
    try:
        reason = Reason.objects.get(pk=pk)
    except Reason.DoesNotExist:
        return Response(status=status.HTTP_404_NOT_FOUND)

    if request.method == 'GET':
        serializer = ReasonSerializer(reason)
        return Response(serializer.data)

    elif request.method == 'PUT':
        serializer = ReasonSerializer(reason, data=request.data)
        if serializer.is_valid():
            serializer.save()
            return Response(status=status.HTTP_204_NO_CONTENT)
        return Response(serializer.errors, status=status.HTTP_400_BAD_REQUEST)

    elif request.method == 'DELETE':
        reason.delete()
        return Response(status=status.HTTP_204_NO_CONTENT)
