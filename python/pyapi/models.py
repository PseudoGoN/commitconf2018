from django.db import models


class Hater(models.Model):
    name = models.CharField(max_length=50)
    surname = models.CharField(max_length=50)
    childTrauma = models.CharField(max_length=100)


class Reason(models.Model):
    hater = models.ForeignKey(Hater, related_name='reasons', on_delete=models.CASCADE)
    title = models.CharField(max_length=20)
    description = models.CharField(max_length=100)
    rageLevel = models.IntegerField()

    class Meta:
        unique_together = ('hater', 'id')
        ordering = ['id']

    def __str__(self):
        return '{}: {}'.format(self.id, self.title)
