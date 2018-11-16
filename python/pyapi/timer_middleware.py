import time
from typing import Callable

from django.core.handlers.wsgi import WSGIRequest


class TimerMiddleware:
    def __init__(self, get_response: Callable):
        self.get_response = get_response

    def __call__(self, request: WSGIRequest):

        # before processing the request
        t0 = time.time()

        response = self.get_response(request)

        # after processing the request
        print(time.time() - t0, "second to process", request)

        return response
