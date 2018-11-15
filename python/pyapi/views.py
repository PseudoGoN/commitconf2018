from rest_framework import status
from rest_framework.decorators import api_view
from rest_framework.response import Response

from pyapi.models import Hater, Reason
from pyapi.serializers import HaterSerializer, ReasonSerializer


@api_view(['GET', 'POST'])
def hater_list(request):
    """
    List all code haters, or create a new hater.
    """
    if request.method == 'GET':
        haters = Hater.objects.all()
        serializer = HaterSerializer(haters, many=True)
        return Response(serializer.data)

    elif request.method == 'POST':
        serializer = HaterSerializer(data=request.data)
        if serializer.is_valid():
            serializer.save()
            return Response(serializer.data, status=status.HTTP_201_CREATED)
        return Response(serializer.errors, status=status.HTTP_400_BAD_REQUEST)


@api_view(['GET', 'PUT', 'DELETE'])
def hater_detail(request, pk):
    """
    Retrieve, update or delete a code hater.
    """
    try:
        hater = Hater.objects.get(pk=pk)
    except Hater.DoesNotExist:
        return Response(status=status.HTTP_404_NOT_FOUND)

    if request.method == 'GET':
        serializer = HaterSerializer(hater)
        return Response(serializer.data)

    elif request.method == 'PUT':
        serializer = HaterSerializer(hater, data=request.data)
        if serializer.is_valid():
            serializer.save()
            return Response(status=status.HTTP_204_NO_CONTENT)
        return Response(serializer.errors, status=status.HTTP_400_BAD_REQUEST)

    elif request.method == 'DELETE':
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
