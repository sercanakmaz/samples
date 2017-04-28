import antispam

d = antispam.Detector("my_model.dat")

msg1 = "Cheap shoes for sale at DSW shoe store!"
print(d.score(msg1))
# => 0.9999947825633266

print(d.is_spam(msg1))
# => True

msg2 = "Hi mark could you please send me a copy of your machine learning homework? thanks"
print(d.score(msg2))
# => 4.021280114849398e-08

print(d.is_spam(msg2))
# => False
