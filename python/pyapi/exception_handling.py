from rest_framework.views import exception_handler


def custom_exception_handler(exc, context):
    print('BEFORE EXCEPTION HANDLING')

    # Call REST framework's default exception handler
    response = exception_handler(exc, context)

    print('AFTER EXCEPTION HANDLING')

    return response
