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
    }

    const handleCVV = (e: any) => {
        setCvv(e.target.value);
    }

    const handleExpiryDate = (e: any) => {
        setExpireDate(e.target.value);
    }
    const handleCardType = (e: any) => {
        setCardType(e.target.value);
    }
    const [message, setMessage] = useState("");

    let handleSubmit = async (e: any) => {
        e.preventDefault();
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
            setMessage(resJson.resultMessage);
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
                    <div className={'column'} style={{ marginRight: '100px', width: '200px' }} id={cardType} onChange={(e) => handleCardType(e)}>
                        <label>Card Type</label>
                        <select className={'form-control'}>
                            <option value="1">Visa</option>
                            <option value="2">AMEX</option>
                            <option value="3">MasterCard</option>
                            <option value="4">Discover</option>
                        </select>
                    </div>
                    <div className={'column'}>
                        <label>Card Number</label>
                        <input type="text" id={cardNumber} className={'form-control'} onChange={(e) => handleCardNumber(e)}></input>
                    </div>

                </div>
            </div>
            <div className={'form-group'}>
                <div className={'row'}>
                    <div className={'column'} style={{ marginRight: '100px', width: '200px' }} >
                        <label>CVV</label>
                        <input type="text" id={cvv} className={'form-control'} onChange={(e) => handleCVV(e)} placeholder="Ex:123"></input>
                    </div>
                    <div className={'column'}>
                        <label>Expiry</label>
                        <input type="text" id={expireDate} className={'form-control'} onChange={(e) => handleExpiryDate(e)} placeholder="mm/yyyy"></input>
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
            {message ?
                <div className={'form-group'}>
                    <div className={'message alert alert-success'} style={{ width: '495px' }}><p>{message}</p></div>
                </div> : null
            }

        </form>
    );
}

export default connect()(Home);
