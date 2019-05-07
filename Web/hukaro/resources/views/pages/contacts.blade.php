<div class="container">
    <div class="row text-center">
        <h2>Send me a message</h2>
    </div>
        <div class="row">
            <div class="col-md-12">
                <div class="form-group">
                    <label for="form_name">Firstname</label>
                    <input id="form_name" type="text" name="name" class="form-control" placeholder="Please enter your firstname" required="required" data-error="Firstname is required.">
                    <div class="help-block with-errors"></div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <div class="form-group">
                    <label for="form_lastname">Lastname</label>
                    <input id="form_lastname" type="text" name="surname" class="form-control" placeholder="Please enter your lastname" required="required" data-error="Lastname is required.">
                    <div class="help-block with-errors"></div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <div class="form-group">
                    <label for="form_email">Email</label>
                    <input id="form_email" type="email" name="email" class="form-control" placeholder="Please enter your email" required="required" data-error="Valid email is required.">
                    <div class="help-block with-errors"></div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <div class="form-group">
                    <label for="form_message">Message</label>
                    <textarea class="form-control" placeholder="Message for me" rows="4" required="required" data-error="Please, leave us a message." style="resize: none;"></textarea>
                    <div class="help-block with-errors"></div>
                </div>
            </div>
            <div class="col-md-12 text-center">
                <button type="submit" class="btn btn-lg btn-outline-primary btn-send btn-block" value="Send message">Send message</button>

            </div>
        </div>
</div>