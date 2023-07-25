import * as React from 'react';
import { connect } from 'react-redux';
import { useState } from "react";

const Home = () => {

    const [cardNumber, setCardNumber] = useState("");
    const [cardType, setCardType] = useState("");
    const [cvv, setCvv] = useState("");
    const [expireDate, setExpireDate] = useState("");

    const handleCardNumber = (e: any) => {
        setCardNumber(e.target.value);
        setCardNumberMessage("");
    }

    const handleCVV = (e: any) => {
        setCvv(e.target.value);
        setCvvMessage("");
    }

    const handleExpiryDate = (e: any) => {
        setExpireDate(e.target.value);
        setExpiryDateErrorMessage("");
    }
    //const handleCardType = (e: any) => {
    //    setCardType(e.target.value);
    //    setCardTypeMessage("");
    //}
    const [apiResponsemessage, setApiResponsemessage] = useState("");

    const [cvvErrorMessage, setCvvMessage] = useState("");
    /*const [cardTypeErrorMessage, setCardTypeMessage] = useState("");*/
    const [cardNumberErrorMessage, setCardNumberMessage] = useState("");
    const [expiryDateErrormessage, setExpiryDateErrorMessage] = useState("");

    const [cssClassMessage, setCssClassMessage] = useState("");

    //const validateCardType = (cardType: string) => {
    //    if (cardType === "" || cardType === '0') {
    //        setCardTypeMessage("Please select a valid card type");
    //        setCssClassMessage('message alert alert-danger');
    //        setApiResponsemessage("");
    //        return false;
    //    }
    //}

    const validateCVV = (cvv: string) => {
        const cvvRegex = /^[0-9\b]+$/;
        if (cvv === '' || cvv.length !== 3 || cvvRegex.test(cvv) === false) {
            setCvvMessage("Please enter valid CVV");
            setCssClassMessage('message alert alert-danger');
            setApiResponsemessage("");
            return false;
        }
    }

    const validateEmptyCardNumber = (cardNumber: string) => {
        if (cardNumber === '') {
            setCardNumberMessage("Please enter valid card number");
            setCssClassMessage('message alert alert-danger');
            setApiResponsemessage("");
            return false;
        }
    }

    const validateExpiryDate = (expiryDate: string) => {
        if (expiryDate === '') {
            setExpiryDateErrorMessage("Please enter valid expiry date in format mm/yyyy");
            setCssClassMessage('message alert alert-danger');
            setApiResponsemessage("");
            return false;
        }
    }

    let handleSubmit = async (e: any) => {
        e.preventDefault();

        if (validateCVV(cvv) === false || validateEmptyCardNumber(cardNumber) === false || validateExpiryDate(expireDate) === false)
            return;

        let formData = new FormData();

        formData.append("CardNumber", cardNumber);
        formData.append("Type", cardType);
        formData.append("CVV", cvv);
        formData.append("ExpireDate", expireDate);

        try {
            let res = await fetch("http://localhost:5093/CreditCardValidator", {
                method: "POST",
                body: formData
            });

            let resJson = await res.json();
            setApiResponsemessage(resJson.resultMessage);
            if (resJson.type === 1)
                setCssClassMessage('message alert alert-success');
            else
                setCssClassMessage('message alert alert-danger');
        } catch (err) {
            console.log(err);
        }
    };

    return (
        <form onSubmit={handleSubmit} className={'form'}>
            <div className={'form-group'}>
                <h1>Validate credit card</h1>
            </div>
            <div className={'form-group'}>
                <div className={'row'}>
                    <div className={'column'} style={{ width: '400px' }}>
                        <label>Card Number</label>
                        <input type="text" id={cardNumber} className={'form-control'} onChange={(e) => handleCardNumber(e)}></input>
                        {cardNumberErrorMessage ?

                            <div className={cssClassMessage} style={{ width: '400px' }}><p>{cardNumberErrorMessage}</p></div> : null
                        }
                    </div>
                </div>

                <div className={'row'} >
                    <div className={'column'} style={{ width: '400px' }}>
                        <label>CVV</label>
                        <input type="text" id={cvv} className={'form-control'} onChange={(e) => handleCVV(e)} placeholder="Ex:123"></input>
                        {cvvErrorMessage ?

                            <div className={cssClassMessage} style={{ width: '400px' }}><p>{cvvErrorMessage}</p></div> : null

                        }
                    </div>
                </div>

                <div className={'row'} >
                    <div className={'column'} style={{ width: '400px' }}>
                        <label>Expiry</label>
                        <input type="text" id={expireDate} className={'form-control'} onChange={(e) => handleExpiryDate(e)} placeholder="mm/yyyy"></input>
                        {expiryDateErrormessage ?

                            <div className={cssClassMessage} style={{ width: '400px' }}><p>{expiryDateErrormessage}</p></div> : null

                        }
                    </div>
                </div>

            </div>
            <div className={'form-group'}>
                <div className={'row'}>
                    <div className={'column'}>
                        <button type="submit" className="btn btn-primary btn-lg">
                            Validate
                        </button>
                    </div>


                </div>
            </div>
            {apiResponsemessage ?
                <div className={'form-group'}>
                    <div className={cssClassMessage} style={{ width: '495px' }}><p>{apiResponsemessage}</p></div>
                </div> : null
            }

        </form>
    );
}

export default connect()(Home);
