$('#QuestionTypeID').change(function () {
    var me = this;

    var selectedId = $(this).val();
    var questionId = $('#QuestionID').val() || 0;

    $.get('/Partials/Index/' + selectedId + '/' + questionId)
        .done(function (data) {
            $('.js-content-placeholder').html(data);
            setTimeout(function () {
                initBinds();
            }, 500);
        })
        .fail(function () {
        });

    
});

function initBinds() {
    $('form').on('submit', onFormSubmit);
    $('.js-create-question-submit-btn').click(onSubmitBtnClick);

    $('.js-one-answer-count').find('input[type=number]').change(onOneAnswerCountChanged);

    
}

function onFormSubmit(e) {
    e.preventDefault();
    return false;
}

function onSubmitBtnClick(e) {
    var questionType = Number($('#QuestionTypeID').val()) || 0;

    var data = {};

    switch (questionType) {
        case 1: {
            data = getOneAnswerData();
            break;
        }
    }

    $.post('/Question/Create', JSON.stringify(data))
        .done(function () {
        })
        .fail(function () {
        });
}

function getOneAnswerData() {
    var result = {
        questionText: $('.js-question-text').find('input[type=text]').val(),
        variants: []
    };

    var inputs = $('.js-one-answer-text-field');

    $.each(inputs, function (index, value) {
        var isRight = $(value).find('input[type=radio]').is(':checked');
        var variantText = $(value).find('input[type=text]').val();
        result.variants.push({
            isRight: isRight,
            text: variantText
        });
    });

    return result;
}

function onOneAnswerCountChanged(){
    var inputsCount = Number($(this).val()) || 0;

    var inputBlock = $('.js-one-answer-inputs-block');
    var itemExample = $($('.js-one-answer-text-field')[0]).detach();

    inputBlock.html('');

    for (var i = 0; i < inputsCount; i++) {
        inputBlock.append(itemExample.clone());
    }
}
