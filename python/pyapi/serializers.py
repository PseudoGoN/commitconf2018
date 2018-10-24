from rest_framework import serializers
from pyapi.models import Hater, Reason


class HaterSerializer(serializers.ModelSerializer):
    reasons = serializers.StringRelatedField(many=True)

    class Meta:
        model = Hater
        fields = ('id', 'name', 'surname', 'childTrauma', 'reasons')


class ReasonSerializer(serializers.ModelSerializer):
    class Meta:
        model = Reason
        fields = ('id', 'title', 'description', 'rageLevel', 'hater')
