# Generated by Django 2.1.2 on 2018-10-20 10:33

from django.db import migrations, models
import django.db.models.deletion


class Migration(migrations.Migration):

    dependencies = [
        ('pyapi', '0001_initial'),
    ]

    operations = [
        migrations.CreateModel(
            name='Reason',
            fields=[
                ('id', models.AutoField(auto_created=True, primary_key=True, serialize=False, verbose_name='ID')),
                ('title', models.CharField(max_length=20)),
                ('description', models.CharField(max_length=100)),
                ('rageLevel', models.IntegerField()),
                ('hater', models.ForeignKey(on_delete=django.db.models.deletion.CASCADE, related_name='reasons', to='pyapi.Hater')),
            ],
        ),
    ]
